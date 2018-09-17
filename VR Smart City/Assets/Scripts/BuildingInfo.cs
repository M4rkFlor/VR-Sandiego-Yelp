using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour {

	[SerializeField]
	private int buildingID;

	public int getBuildingId() {
		return(buildingID);
	}

}
