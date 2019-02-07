using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {
    public float jumpSpeed;

    private Character mController;
    private Rigidbody mRb;
    private Camera mCamera;
    [SerializeField] private MouseLook mMouseLook = new MouseLook();

	// Use this for initialization
	void Start () {
        mController = GetComponent<Character>();
        mRb = GetComponent<Rigidbody>();
        mCamera = Camera.main;
        mMouseLook.Init(transform, mCamera.transform);
    }
	
    Vector3 GetDirectionVec3(float angle)
    {
        Vector3 vec3 = Vector3.zero;
        vec3.x = Mathf.Sin(Mathf.Deg2Rad * angle);
        vec3.z = Mathf.Cos(Mathf.Deg2Rad * angle);

        return vec3;
    }
	// Update is called once per frame
	void Update () {
        // = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
        mMouseLook.LookRotation(transform, mCamera.transform);
        Vector3 move = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
            move += GetDirectionVec3(mCamera.transform.rotation.y);
        if (Input.GetKey(KeyCode.A))
            move += GetDirectionVec3(mCamera.transform.rotation.y - 90);
        if (Input.GetKey(KeyCode.S))
            move += GetDirectionVec3(mCamera.transform.rotation.y - 180);
        if (Input.GetKey(KeyCode.D))
            move += GetDirectionVec3(mCamera.transform.rotation.y + 90);

        mController.CharacterMove(move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump(jumpSpeed);
        }
    }

    private void FixedUpdate()
    {
        mMouseLook.UpdateCursorLock();
    }

    void PlayerMove(Vector3 move)
    {
        mController.CharacterMove(move);
    }

    void PlayerJump(float _speed)
    {
        mController.CharacterJump(_speed);
    }
}
