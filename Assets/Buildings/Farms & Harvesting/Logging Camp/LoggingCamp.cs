using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggingCamp : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	public override bool ValidHex(Hex hex) {
		return hex.Terrain == TerrainType.Forest;
	}

	//Up to 8 workers, each worker generates a wood every 4 units, 8 if replanting area (0.25 or 0.125 gold/unit)
}
