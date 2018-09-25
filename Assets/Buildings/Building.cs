using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	public int buildCost;

	public virtual void Start() {
		Debug.Log("Building");
	}

	public virtual bool ValidHex(Hex hex) {
		return hex.terrain == TerrainType.Clearing;
	}

	public virtual void Place(Hex hex) {
		if (hex == null || hex.building != null || !ValidHex(hex)) {
			gameObject.SetActive(false);
			return;
		}

		gameObject.SetActive(true);

		transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + 0.5f, hex.transform.position.z);
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
	}

	public virtual void Work() {
		Debug.Log("Work");
	}
}
