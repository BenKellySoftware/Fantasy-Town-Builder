using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building {
	public List<Resource> storage = new List<Resource>();
	public const int capacity = 10;
	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	public override bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}
}