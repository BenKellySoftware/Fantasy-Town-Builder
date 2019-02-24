using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : BuildingAction {
	public override bool Use(Citizen user, Inventory inventory) {
		user.rest++;
		return user.rest < 50;
	}
}
