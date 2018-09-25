using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {
	public static int ResourceCount(List<Resource> storage) {
		int sum = 0;
		foreach (Resource resource in storage) {
			sum += resource.count;
		}
		return sum;
	}

	public static Map map {
		get {
			return GameObject.Find("Map").GetComponent<Map>();
		}
	}

	public static MouseInput input {
		get {
			return GameObject.Find("Main Camera").GetComponent<MouseInput>();
		}
	}
}

[System.Serializable]
public struct Coordinates {
	public int x, y;

	public override string ToString() {
		return "x: " + x + ", y: " + y;
	}
}

public enum TerrainType {
	Clearing,
	ForestEdge,
	Forest,
	Coast,
	Shore,
	Sea,
	Mountain,
	MountainSide
};