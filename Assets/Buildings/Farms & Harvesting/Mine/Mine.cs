using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Mine");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.MountainSide;
	}

	//Upgrade to go deeper in the mine to increase chances

}
