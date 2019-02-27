using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Structure : MonoBehaviour { //Anything that exists on a hex
}

public class Building : Structure { //Anything placed by the player
	public int buildCost;
	public int buildTime;
	public HexValidator validator;
	public Inventory inventory;
	public List<BuildingAction> actions;
	public int rotation;

	public virtual void Place(Hex hex) {
		if (Input.GetButtonDown("Rotate")) rotation = rotation + 1 % 6;

		if (hex == null || hex.structure != null) {
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);

		transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, hex.transform.position.z);
		if (!validator.Valid(hex)) {
			GetComponent<Renderer>().material.color = Color.red;
			return;
		}
		GetComponent<Renderer>().material.color = Color.white;

		if (Input.GetMouseButtonDown(0)) {
			
			hex.structure = Instantiate(this);
			hex.structure.name = this.name;
			hex.structure.transform.SetParent(hex.transform);
			Init(); //Todo, set to be built before activating
		}
	}

	public void Init() {

	}

	public void Use(Citizen citizen) {
		foreach (BuildingAction action in actions) {
			if(action.active && action.Available(citizen, this)) {
				action.Use(citizen, this);
			}
		}
	}
}


public class Path : Building {
	public bool[] neighboursLinked = new bool[6];

	//For use with place
	Hex start;
	Hex end;

	public override void Place(Hex hex) {
		// Click start and end, or drag a line	
	}
}

public class Zone : Building {
	public bool[] neighboursLinked = new bool[6];

	//For use with place
	Hex start;
	Hex end;

	public override void Place(Hex hex) {
		// Click start and end, or drag a rectangular area, selecting all valid tiles	
	}
}

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


