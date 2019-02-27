using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIAction : ScriptableObject {
	public abstract void Use();
}

public class ShowMenu : UIAction {
	public GameObject building;
	public override void Use() {
		
	}
}

public class SelectBuilding : UIAction {
	public Building building;
	public override void Use() {
		Controls.selectedBuilding = building;
	}
}