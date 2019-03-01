using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Building : Structure { //Anything placed by the player
	public int buildCost;
	public int buildTime;
	public HexValidator validator;
	public Inventory inventory;
	public List<BuildingAction> actions;
	public int rotation;

	public virtual void Place(Hex hex) {
		
		if (Input.GetButtonDown("Rotate")){Debug.Log("Hello"); rotation = rotation + 1 % 6;}

		if (hex == null || hex.structure != null) {
			gameObject.SetActive(false);
			return;
		}
		gameObject.SetActive(true);

		transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, hex.transform.position.z);
		transform.eulerAngles = new Vector3(0,60*rotation,0);

		if (!validator.Valid(hex)) {
			transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
			return;
		}
		transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;

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
