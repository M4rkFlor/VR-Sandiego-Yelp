using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticMovement : MonoBehaviour {

	[SerializeField]
	float moveSpeed;
	[SerializeField]
	float lookSpeed;
	[SerializeField]
	float maxDistanceFromPoint;
	[SerializeField]
	Vector3 origin;

	public string name; 
	// Use this for initialization
	void Start () {
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		float zMovement = Input.GetAxis("Vertical");
		float xMovement = Input.GetAxis("Horizontal");
		float yMovement = Input.GetAxis("XboxRb")-Input.GetAxis("XboxLb");
		Vector3 translation = new Vector3(xMovement, yMovement, zMovement) * Time.deltaTime * moveSpeed;
		transform.Translate(translation);
	//	if(Vector3.Distance(transform.position, origin) > maxDistanceFromPoint) {
	//		transform.Translate(-translation);
	//	}

		float xRotation = Input.GetAxis("Mouse Y");
		float yRotation = Input.GetAxis("Mouse X");
		Vector3 rotation = new Vector3(xRotation, -yRotation, 0.0f) * lookSpeed * Time.deltaTime;
		transform.eulerAngles -= rotation;
	}
	public void getName(string n){
		name = n; 
	}
}