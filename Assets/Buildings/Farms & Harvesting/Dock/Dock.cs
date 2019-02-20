using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dock : Pathway {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Dock");
	}

	public override bool ValidHex(Hex hex) {
		for (int i = 0; i < 6; i++) {
			Hex neighbour = hex.FindNeighbour(i);
			//Returns true if on the shore or if next to exsisting docks
			if (neighbour != null && neighbour.building != null && neighbour.building.name == "Dock" && hex.Terrain == TerrainType.Shallows) {
				return true;
			}
		}
		return hex.Terrain == TerrainType.Coast;
	}
}
