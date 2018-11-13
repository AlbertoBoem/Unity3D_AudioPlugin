using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			
	}


	void OnCollisionEnter(Collision target) {

		if (target.gameObject.tag == "touchCube") {

			Debug.Log ("Enter called");

		}

	}

}
