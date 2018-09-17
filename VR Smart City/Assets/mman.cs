using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mman : MonoBehaviour {

	public bool gravityIsOn=true; 
	float rotateOffset  = 0.0f;
	//float speedInAir				= 1.0f;						// var inAirControlAcceleration
	float gravity					= 20.0f;						// gravity (downward pull only, added to vector.y) 
	//private Vector3 inAirVelocity			= Vector3.zero;				// current currentSpeed while in air 
	private float verticalSpeed				= 0.0f;						// speed for vertical use
	private CollisionFlags collisionFlags;								// last collision flag returned from control move

	//@HideInInspector																	// hide characterController in the inspector but keep public - for now
	CharacterController characterController;							// instance of character controller
	//@HideInInspector 

	static float moveSpeed				= 0.0f;						// current player moving speed
	private Vector3 moveDirection			= Vector3.forward;				// store initial forward direction of player
	private float smoothDirection			= 10.0f;						// amount to smooth camera catching up to player

	float timeVal  = 0;
	bool crouch=false;
	public Camera cameraObject;										// player camera  (usually main camera)

	bool jump;
	Vector3 startPos;

	// Use this for initialization
	void Start () {    
		characterController = GetComponent<CharacterController>();						// initialize characterController
		characterController.tag = "Player";												// set tag name to 'Player'	
		startPos=transform.position;
	}
	void UpdateMoveDirection 	() {

		Vector3 forward = cameraObject.transform.TransformDirection ( Vector3.forward );	// forward vector relative to the camera along the x-z plane
		forward.y = 0;																	// up/down is set to 0
		forward = forward.normalized;													// set forward between 0-1	
		Vector3 right = new Vector3( forward.z, 0, -forward.x );						// right vector relative to the camera, always orthogonal to the forward vector


		float vertical   = Input.GetAxisRaw ( "Vertical"   );						// get input vertical
		float horizontal = Input.GetAxisRaw ( "Horizontal" );						// get input horizontal


		if (vertical == 0.0f && horizontal == 0.0f)
		{
			timeVal = 0;
			moveSpeed = 0.0f;
		}
		else
		{
			timeVal += Time.deltaTime*3;
			moveSpeed = 1.0f * timeVal;	
		}


		Vector3 targetDirection = horizontal * right + vertical * forward;		// target direction relative to the camera

		if ( IsGrounded () )															// if player on ground
		{
			if ( targetDirection != Vector3.zero )										// store currentSpeed and direction separately
			{
				moveDirection = Vector3.Lerp ( moveDirection, targetDirection, smoothDirection * Time.deltaTime );	// smooth camera follow player direction
				moveDirection = moveDirection.normalized;								// normalize (set to 0-1 value)
			}	

															// check for player walking
			Jump ();
		}

		//else																			// if player is in air 
		//{										
		//	inAirVelocity += targetDirection.normalized * Time.deltaTime * speedInAir;	// if in air, move player down based on velocity, direction, time and speed
		//}		


	}




	// Update is called once per frame
	void Update () {

		SetGravity ();																// pulls character to the ground 'if' in air
		// pulls character to the ground 'if' in air
		UpdateMoveDirection ();														// motor, direction and ani for player movement
		//moves mario.				
		Vector3 movement = moveDirection * moveSpeed + new Vector3 ( 0, verticalSpeed, 0 ); //+ inAirVelocity; // stores direction with speed (h,v)
		movement *= Time.deltaTime;													// set movement to delta time for consistent speed

		//moves mario.				
		collisionFlags = characterController.Move ( movement );						// move the character controller	

		if ( IsGrounded () ) 														// character is on the ground (set rotation, translation, direction, speed)
		{
			//orients mario to the direction he is moving.		
			//			transform.rotation = Quaternion.LookRotation ( moveDirection );			// set rotation to the moveDirection
			//			transform.rotation.eulerAngles.y += rotateOffset;

			Quaternion q = Quaternion.LookRotation ( moveDirection );
			transform.rotation = new Quaternion (q.x,q.y+rotateOffset,q.z,q.w);



			//inAirVelocity = new  Vector3(0,-0.1f,0);										// turn off check on velocity, set to zero/// current set to -.1 because zero won't keep him on isGrounded true. goes back and forth			
			if ( moveSpeed < 0.15f ) 												// quick check on movespeed and turn it off (0), if it's
			{
				moveSpeed = 0;														// less than .15
			}
		}
		if (Input.GetKeyDown ("c")) {
			crouch = !crouch;
		}
		if (crouch == true) {
			print("crouch");
			if (timeVal>4) {
				print ("speed limit");
				timeVal = 4;
			}

		}
		Jump (); 
		if (Input.GetAxis ("XboxY")!=0) {
			gravityIsOn = !gravityIsOn; 
		}

		//anim.SetBool ("jump", jump);

		if (this.GetComponent<CharacterController> ().isGrounded) {
			//movement.y = 0;
			//jump = false;
			print(IsGrounded());
		}

		//print (movement.y);
	}




	//////////////////////////////////////////////////////////////
	void Jump(){
		if (Input.GetButtonDown ("XboxRb")) {
			
				verticalSpeed += 8;
				
			}
		if (Input.GetButtonDown ("XboxLb")) {

			verticalSpeed = -8;

		}
		}



	////////////////////////////////////////////////////////////////////
	
	////////////////////////////////////////////////////////////////////
	
	void tele 					() {	
		transform.position=startPos;
	}
	////////////////////////////////////////////////////////////////////
	bool IsGrounded 			() {												// check if player is touching the ground or a collision flag
		return ( collisionFlags & CollisionFlags.CollidedBelow ) != 0;					// if isGround not equal to 0 if it doesn't equal 0
	}
	////////////////////////////////////////////////////////////////////
	void SetGravity				() {												// sets gravity to 0 for ground and subtracts if in air
		//if ( IsGrounded () || gravityIsOn==false)
		//	verticalSpeed = 0.0f;														// stop subtracting, if player on ground set to 0
		//if(gravityIsOn)
			//verticalSpeed -= gravity * Time.deltaTime;									// if character in air, begin moving downward
	}



}
