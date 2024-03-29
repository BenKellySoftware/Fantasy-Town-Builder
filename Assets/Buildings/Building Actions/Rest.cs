﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : BuildingAction {

	public override bool Available(Citizen user, Building building) {
		return user.rest < 50;
	}

	public override void Use(Citizen user, Building building) {
		user.rest++;
	}
}
