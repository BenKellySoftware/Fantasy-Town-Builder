using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpenters : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	//Set to produce either Arcane focuses, Weapons, or Instruments
	//Staves:
	//	Requires 2 lumber
	//	Worth 2 + value * 2 (

}
