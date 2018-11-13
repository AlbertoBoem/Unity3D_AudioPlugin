using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eventCtrl : MonoBehaviour {

	public FaustPlugin_karplus karplus;

	public GameObject Cube;  //first get the object (drag from game object inside inspector
	Transform trans_cube; //then get its properties


	float x;
	float x1;
	int param = 0; //5
	int param1 = 5;
	float startstop = 0;

	int CountCollisions = 0;


	float multiply = 100f;

	// Use this for initialization
	void Start () {

		trans_cube = Cube.GetComponent<Transform> (); //get the transform components

		karplus = GetComponent<FaustPlugin_karplus>(); //instead of declaring public FaustPlugin_karplus karplus;
		//x1 = 0;
		//x1 = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		//karplus.setParameter(param, x);
		//karplus.setParameter(param1, 1f);
	
	
		//if (Input.GetKeyDown (KeyCode.Space)) { 
			//x += 10f;
			//karplus.setParameter(param, x);
			//x1 = 1; ALL NOT USED
			karplus.setParameter(param1, startstop); //1
		//} 
		//karplus.setParameter(param1, x1);
		//else if (Input.GetKeyUp(KeyCode.Space)){
			//x1 = 0; NOT USED
		//	karplus.setParameter(param1, 0); //0
		//}



		x1 = (trans_cube.localScale.x) * multiply; //get the local scale

		x = scale (100, 1000, 1000, 100, x1);

		karplus.setParameter (param, x); //x1
		/*
		if (Input.GetKeyDown ("a")) { 
			//x += 100;
			karplus.setParameter (param, 600);
		} else if(Input.GetKeyUp ("a")) {
			karplus.setParameter (param, 200);
		}
		*/

		//else if (Input.GetKeyUp(KeyCode.UpArrow)){
		//x1 = 320f; 
		//}

		//transform.localScale.x
		//public Transform

	}

	//awsome max-like scale function
	public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){

		float OldRange = (OldMax - OldMin);
		float NewRange = (NewMax - NewMin);
		float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

		return(NewValue);
	}

	void OnCollisionEnter(Collision target) {

		if (target.gameObject.tag == "touchCube") {

			CountCollisions++;

			startstop = 1;

			Debug.Log ("Enter called");

		}

	}



	void OnCollisionStay(Collision target) {

		if (target.gameObject.tag == "touchCube") {

			 //CountCollisions++

			//if(target.contacts[0].normal.x >= 0.6f){

			if(CountCollisions > 5) {

			startstop = 0;
			//Debug.Log ("Stay in touch");

		}
			Debug.Log ("Stay in touch");

	  }
	}



	void OnCollisionExit(Collision target) {

		if (target.gameObject.tag == "touchCube") {

			CountCollisions = 0;
			startstop = 0;
			Debug.Log ("Collision exit!!!");
		}

	}


}
