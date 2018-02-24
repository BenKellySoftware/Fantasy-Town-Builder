using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tailor : Building {

	public override void Start() {
		base.Start();
		Debug.Log("This is a Tailor");
	}
	//2 Fabric -> Clothes or Robes, 3 + 1.5x value, takes 20 units to make per worker
	//2 Leather, 1 Fabric -> Light Armour, 4 + 1.5x base value, 30 units to make per worker
	//Up to 2 workers per shop
	//Standard Clothes/ Robes (non magic) = 15 gold, 7 profit (0.35 profit/ unit)
	//Standard Light Armour = 25 Gold (4 + 14 * 1.5), 13 profit (0.43 profit/ unit)
}
