using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testinputz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("XboxA") > 0) {
			transform.Translate (0, 1, 0); 
		}
		if (Input.GetAxis("Mouse Y") > 0) {
			transform.Rotate (0, 5, 0);
		}
		if (Input.GetAxis("Mouse Y") < 0) {
			transform.Rotate (0, 5, 0);
		}
	}
	public void rotateGameObj(){
		transform.Rotate (0, 45, 0);
		//transform.Translate (0, .4f, 0); 
	}
}
