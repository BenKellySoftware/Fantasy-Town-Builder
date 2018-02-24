using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantation : Zone {
	public ResourceType type;
	public int plantTime = 15;
	public int growTime = 50;
	public int harvestTime = 10;
	public int yieldAmount = 6;

	public override void Start() {
		base.Start();
		Debug.Log("This is a Plantation");
	}

	public override void Setup(ResourceType type) {
		this.type = type;
		this.name = type.singular + " Farm";
		if (type.name == "Flax" || type.name == "Hemp") {
			yieldAmount = 3;
		}
	}

	//Produces selected resource type, takes 15 to plant, 50 to grow, 10 to harvest, generates 6 units per tile (3 for Flax or Hemp)
	//Each worker can work 3 tiles if constantly working on other plots
	//Produce * Tiles * Price / Time
	//6*3 / 75 = 0.24 Profit/Unit
}
