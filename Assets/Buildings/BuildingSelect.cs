using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelect : MonoBehaviour {
	static int rotateSpeed = 20;
	public GameObject building;
	public ResourceType type;
	void Update() {
		transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
	}

	public void Select() {
		
		if (Utilities.input.selectedBuilding) {
			Destroy(Utilities.input.selectedBuilding);
		}
		Utilities.input.selectedBuilding = Instantiate(building, new Vector3(-100, 0, -100), Quaternion.identity);
		Utilities.input.selectedBuilding.name = building.name;
		if (type) {
			Utilities.input.selectedBuilding.SendMessage("Init", type, SendMessageOptions.DontRequireReceiver);
		}
	}
}
