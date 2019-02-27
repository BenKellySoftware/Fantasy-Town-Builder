using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Recipe : BuildingAction {

	public List<ResourceCategory> inputs;
	public ResourceType output;

	public override bool Available(Citizen user, Building building) {
		return !inputs.Any(input => building.inventory.FindByCategory(input).Count == 0); // Check if any ingredients are unavailable
	}

	//Warning, theres no error checking if the inventory will be full and drop the output
	//Shouldn't matter since your always consuming at least as much as you output, but if something breaks, it's this.
	public override void Use(Citizen user, Building building) {
		int value = 0;
		foreach (var input in inputs) {
			Resource stack = building.inventory.FindByCategory(input).First();
			value += stack.value;
			stack.count--;
			if (stack.count == 0) building.inventory.resources.Remove(stack); // Remove stack if empty
		}
		//TODO custom name generation based on inputs
		value = (int)(value * output.inputMultiplier + output.baseValue);
		building.inventory.Add(new Resource(output.name, output, value, 1, true));
	}
}
