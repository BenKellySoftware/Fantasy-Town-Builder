using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource Type", order = 1)]
public class ResourceType: ScriptableObject {
	public string category;
	public int baseValue;

	public string singular {
		get {
			if (name.EndsWith("ies")) {
				return name.Replace("ies", "y");
			} else if (name.EndsWith("s")) {
				return name.Remove(name.Length - 1, 1);
			} else {
				return name;
			}
		}
	}
}