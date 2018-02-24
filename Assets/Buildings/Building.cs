using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	
	public virtual void Start() {
		Debug.Log("Building");
	}

	public virtual bool ValidHex(Hex hex) {
		return hex.terrain == (int)TerrainTypes.Clearing;
	}

	public virtual void Setup(ResourceType type) {
		Debug.Log("Default");
	}
}