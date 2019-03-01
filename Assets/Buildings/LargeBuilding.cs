using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LargeBuilding : Building {
	public bool[] shape = new bool[6]; //the neighbours surrounding the main hex at rotation 0

	public override void Place(Hex hex) {
		if (Input.GetButtonDown("Rotate")) rotation = rotation + 1 % 6;

		List<Hex> hexes = new List<Hex>(6);
		for (int i = 0; i < 6; i++) {
			if(shape[i]) hexes.Add(hex.FindNeighbour(i + rotation % 6));
		}

		if(hexes.Any(x => x == null || x.structure != null)) {
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);

		transform.position = new Vector3(hexes[0].transform.position.x, hexes[0].transform.position.y, hexes[0].transform.position.z);
		transform.eulerAngles = new Vector3(0,60*rotation,0);

		if (!validator.Valid(hex)) {
			GetComponent<Renderer>().material.color = Color.red;
			return;
		}

		GetComponent<Renderer>().material.color = Color.white;
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Place");
			hex.structure = this;
			transform.SetParent(GameObject.Find("Buildings").transform);
			Init(); //Todo, set to be built before activating
		}
	}
}
