using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Build : BuildingAction {
	public override bool Available(Citizen user, Building building) {
		return true;
	}

	public override void Use(Citizen user, Building building) {
		
	}
}
