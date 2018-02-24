using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Market Stall");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}
}