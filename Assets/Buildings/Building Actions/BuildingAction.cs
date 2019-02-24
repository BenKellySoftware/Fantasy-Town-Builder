using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingAction : ScriptableObject {
	public bool active;
	public int jobLength;
	// Returns false when job can't be done anymore
	public abstract bool Use(Citizen user, Inventory inventory);
}
