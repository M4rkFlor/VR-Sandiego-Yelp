using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMe : MonoBehaviour {
	public string myName;
	// Use this for initialization
	void Start () {
		myName = this.gameObject.name; 
	}
	
	public void giveMyName(){
		GameObject.Find ("Player").GetComponent<KineticMovement> ().getName (myName); 
	}
}
