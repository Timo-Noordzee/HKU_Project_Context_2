using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MoveScaffold")
        {
        }
    }

    Vector3 GetDirectionVec3(float angle)
    {
        Vector3 vec3 = Vector3.zero;
        vec3.x = Mathf.Sin(Mathf.Deg2Rad * angle);
        vec3.z = Mathf.Cos(Mathf.Deg2Rad * angle);

        return vec3;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "MoveScaffold")
        {
            CharacterController mController = GetComponent<CharacterController>();
            Vector3 moveVector = hit.gameObject.GetComponent<MoveScaffold>().Move;
            //mController.Move();
            Vector3 move = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                move += GetDirectionVec3(Camera.main.transform.rotation.y);
            if (Input.GetKey(KeyCode.A))
                move += GetDirectionVec3(Camera.main.transform.rotation.y - 90);
            if (Input.GetKey(KeyCode.S))
                move += GetDirectionVec3(Camera.main.transform.rotation.y - 180);
            if (Input.GetKey(KeyCode.D))
                move += GetDirectionVec3(Camera.main.transform.rotation.y + 90);

            transform.position += moveVector * Time.deltaTime;
            transform.Translate(move * Time.deltaTime * 3);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "MoveScaffold")
        {
            Vector3 position = transform.position;
            position += collision.gameObject.GetComponent<MoveScaffold>().Move * Time.deltaTime;
            transform.position = position;
        }
    }
}
