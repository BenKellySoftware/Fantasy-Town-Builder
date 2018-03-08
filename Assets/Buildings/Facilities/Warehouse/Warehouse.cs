using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : Building {
	public int storageLimit = 50;

	public override void Start() {
		base.Start();
		Debug.Log("This is a Warehouse");
	}
}
