using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Character : MonoBehaviour {

    public float speed = 7.0f;
    private Rigidbody mRb;

	// Use this for initialization
	void Start () {
        mRb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 CharacterMove(Vector3 mVector3)
    {
        transform.Translate(mVector3 * speed * Time.deltaTime);
        return mVector3;
    }

    public float CharacterJump(float speed)
    {
        mRb.AddForce(new Vector3(0, speed));
        return speed;
    }
}
