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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CharacterController mController = GetComponent<CharacterController>();
        if (hit.gameObject.tag == "MoveScaffold")
        {
            Vector3 position = transform.position;
            mController.Move(hit.gameObject.GetComponent<MoveScaffold>().Move * Time.deltaTime);
            transform.position = position;
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
