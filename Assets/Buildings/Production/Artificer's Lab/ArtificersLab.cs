using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificersLab : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is an Artificer's Lab");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}
}
