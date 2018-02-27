using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpenters : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a House");
	}

	//Set to produce either Arcane focuses, Weapons, or Instruments
	//Staff, Light Weapon:
	//	Requires 2 lumber
	//	Worth 3 + supplies * 1.5 (min 12, max 33)
	//Wand:
	//	Requires 1 lumber 1 gemstone
	//	Worth 2 + supplies * 1.5 (min 22, max 107)
	//Flute:
	//	Requires 2 lumber
	//Drum:
	//	Requires 1 lumber, 1 leather
	//Bow, Lute:
	//	Requires 1 lumber, 1 string
	//Arrows:
	//	Requires 1 lumber, 1 feathers, 1 metal (optional)

}
