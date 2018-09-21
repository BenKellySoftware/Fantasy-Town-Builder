using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Pathway {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Dock");
	}

	public override bool ValidHex(Hex hex) {
		foreach (Hex neighbour in hex.neighbours) {
			//Returns true if on the shore or if next to exsisting docks
			if (neighbour != null && neighbour.building != null && neighbour.building.name == "Dock" && hex.terrain == TerrainType.Coast) {
				return true;
			}
		}
		return hex.terrain == TerrainType.Shore;
	}
}
