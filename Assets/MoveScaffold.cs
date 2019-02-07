using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScaffold : MonoBehaviour {

    [SerializeField] private Vector3 moveDir;
    [SerializeField] private float maxDistance;
    private float moveDistance;
    private Vector3 move;

    public Vector3 Move
    {
        get
        {
            return move;
        }

        set
        {
            move = value;
        }
    }

    // Use this for initialization
    void Start () {
        move = moveDir;
        moveDistance = 0;

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(move * Time.deltaTime);

        moveDistance += Mathf.Abs(move.x * Time.deltaTime);
        moveDistance += Mathf.Abs(move.z * Time.deltaTime);

        if(moveDistance > maxDistance)
        {
            moveDistance = 0;
            move = -move;
        }
    }
}
