using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpSpeed;

    private CharacterController mController;
    private Rigidbody mRb;

	// Use this for initialization
	void Start () {
        mController = GetComponent<CharacterController>();
        mRb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (move.x != 0)
            PlayerMove(move);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump(jumpSpeed);
        }
    }

    void PlayerMove(Vector3 move)
    {
        mController.CharacterMove(move);
        if(move.x < -0.01)
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void PlayerJump(float _speed)
    {
        mController.CharacterJump(_speed);
    }
}
