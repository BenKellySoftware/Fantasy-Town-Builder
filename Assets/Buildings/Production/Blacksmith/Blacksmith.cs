using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blacksmith : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Blacksmith");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == TerrainType.Clearing;
	}
}
