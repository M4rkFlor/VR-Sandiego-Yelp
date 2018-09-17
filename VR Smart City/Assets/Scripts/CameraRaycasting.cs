using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour {

	[SerializeField]
	float raycastDistance = 15;
	[SerializeField]
	string targetTag = "Building";
	[SerializeField]
	GameObject canvas;

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray cameraRay = new Ray(Camera.main.transform.forward, Camera.main.transform.position);

        if (Physics.Raycast(cameraRay, out hit)) {
			GameObject hitObject = hit.transform.gameObject;
			if(hitObject.tag.Equals(targetTag)) {
				// print(hitObject.GetComponent<BuildingInfo>().getBuildingId());
				//print(hitObject.gameObject);
				if (Input.GetAxis ("XboxB") > 0) {
					canvas.GetComponent<CanvasManager>().triggerNewFocus(hitObject.gameObject.name.ToLower());
				}
			}
		}
	}
}
