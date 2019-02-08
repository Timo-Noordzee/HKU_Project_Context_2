using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour {

    [SerializeField] private List<Vector3> point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Lerp(transform.position, point[0], 0.1f);
	}

    Vector3 Lerp(Vector3 p1, Vector3 p2, float d)
    {
        return p1 + (p2 - p1) * d;
    }
}
