using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawmill : Building {

	public ResourceType consumes = GameObject.Find("Wood").GetComponent<ResourceType>();

	public override void Start() {
		base.Start();
		Debug.Log("This is a Sawmill");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Shore;
	}

	//Makes Lumber from Wood:
	//1 Wood per Lumber, Takes 8 units to make per worker, 2 gold profit (0.25 gold/unit)
	//Takes up to 4 workers
}
