using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haberdashery : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}
}
