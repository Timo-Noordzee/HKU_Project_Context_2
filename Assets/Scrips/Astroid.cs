using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid: MonoBehaviour {

    private float size;

    private void Start() {

    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject, 1.0f);
    }

    private void Update() {

    }

}
