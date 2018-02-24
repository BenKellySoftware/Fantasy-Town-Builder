using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddock : Zone {
	public ResourceType resourceType;

	public override void Start() {
		//name = resourceType.name + "Paddock";
		base.Start();
		Debug.Log("This is a Paddock");
	}

	//
}
