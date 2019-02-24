using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Recipe : BuildingAction {

	public List<ResourceCategory> inputs;
	public Resource output;
	public 
	override bool Use(Citizen worker, Inventory inventory) {
		List<Resource> ingredients = new List<Resource>();
		foreach (var input in inputs) {
			ingredients.Add(inventory.FindByCategory(input).First());
		}
		foreach (var ingredient in ingredients) {
			if (ingredient == null) return false;
			ingredient.count--;
			if(ingredient.count == 0) inventory.resources.Remove(ingredient); // Remove if empty
		}
		return true;
	}
}
