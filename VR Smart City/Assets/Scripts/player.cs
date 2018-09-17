using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour {
	public float speed;
	public CharacterController c; 
	public float gravity; 
	float y;
	float x; 
	float rx;
	float ry;
	float rz;
	Vector3 dir;
	//private Rigidbody rb;

	void Start ()
	{
		//Time.timeScale = 0.001f;

		c = this.GetComponent<CharacterController> ();
		gravity = -10;
		dir = Vector3.zero;

		//rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		dir = new Vector3 (x,y,0.0f);
		c.Move (dir);


		/*Vector3 worldSpace = transform.TransformVector(new Vector3(0, 0, Time.deltaTime * (1 + ((y+2) * 8f))));
		Vector3 ls2 = transform.InverseTransformVector(worldSpace);
		GetComponent<CharacterController>().Move(ls2);
		*/
		/*if (y > 0f) {
			
			c.Move (Vector3.left * 3f * Time.deltaTime);
		}
		if (y < 0f) {
			c.Move (Vector3.right * 3f * Time.deltaTime);
		}
		if (x > 0f) {
			c.Move (Vector3.forward * 3f * Time.deltaTime);
		}
		if (x < 0f) {
			c.Move (Vector3.back * 3f * Time.deltaTime);
		}
	*/


		rx = Input.GetAxis("XboxRb");
		ry = -Input.GetAxis("XboxLb");
		//print (String.Format ("rb={0}, lb={1}", rx, ry));
		rz = 0;
	this.transform.Rotate(new Vector3(0, rx + ry, 0), Space.World);
	}

}