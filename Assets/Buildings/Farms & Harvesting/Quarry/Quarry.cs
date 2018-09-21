using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Quarry");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == TerrainType.MountainSide;
	}
}
