using UnityEngine;
using System.Collections;

public class CmeraController : MonoBehaviour {

	public Transform target;							// target for camera to look at
	private float targetHeight 		= 1.0f;					// height of target
	private float distance 			= 8.0f;					// distance between target and camera
	private float xSpeed 			= 250.0f;				// movement on horizontal
	private float x 				= 0.0f;					// store axis x from input
	private float y 				= 0.0f;					// store axix y from input
	private float ySpeed 			= 250.0f;
	private float zSpeed 			= 40.0f;

	// Use this for initialization
	void Start () {
		Vector2 angles = transform.eulerAngles;															// set vector 2 values from this transform (camera)
		x = angles.y;																							// set x to equal angle x
		y = angles.x;		
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 vTargetOffset;																			// store vertical target offset amount (x,y,z)

		x += Input.GetAxis("CameraX") * xSpeed * 0.02f;															// set x to axis movement horizontal
		y += Input.GetAxis("CameraY") * ySpeed * 0.02f;	

		//if (Input.GetButtonDown ("u")) {
			//x += Input.GetAxis("Zoom") * xSpeed * 0.02f;															// set x to axis movement horizontal
			//y += Input.GetAxis("Zoom") * ySpeed * 0.02f;
		distance+=Input.GetAxis("Zoom") * zSpeed * 0.02f;
		//}
		//if (Input.GetButtonDown ("o")) {
		//	x += Input.GetAxis("Zoom") * xSpeed * 0.02f;															// set x to axis movement horizontal
		//	y += Input.GetAxis("Zoom") * ySpeed * 0.02f;		
		//}
		//*/
		// set y to axis movement vertical
		Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(y, x, 0), Time.deltaTime * 3);		// set rotation value to equal the rotation of the camera and time

		vTargetOffset = new Vector3 (0, -targetHeight, 0);														// calculate desired camera position
		Vector3 position = target.position - (rotation * Vector3.forward * distance + vTargetOffset); 			// set camera position and angle based on rotation, wanted distance and target offset amount

		transform.rotation = rotation;																			// set camera rotation to current rotation amount
		transform.position = position;			
	}
}
