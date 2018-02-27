using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public int buildCost;

	public virtual void Start() {
		Debug.Log("Building");
	}

	public virtual bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}

	public virtual void Place(Vector3 point) {
		Coordinates pos = Map.CoordsByWorldPos(point);
		Hex hex = Utilities.map.FindHex(pos.x, pos.y);
		if (hex == null || hex.building != null || !ValidHex(hex)) {
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);
		transform.position = new Vector3(hex.WorldSpace.x, point.y + 0.2f, hex.WorldSpace.y);
		//if (!ValidHex(hex)) {
		//	GetComponent<Renderer>().material.color = Color.red;
		//	return;
		//}
		//GetComponent<Renderer>().material.color = Color.white;
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Place");
			hex.building = gameObject;
			transform.SetParent(GameObject.Find("Buildings").transform);
			Utilities.input.selectedBuilding = null;
			Build();
		}
	}

	public virtual void Build() {
		Debug.Log("Default");
	}
}