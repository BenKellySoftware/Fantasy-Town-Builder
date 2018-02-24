using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggingCamp : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.ForestEdge;
	}
}
