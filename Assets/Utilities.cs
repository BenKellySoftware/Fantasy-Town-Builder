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

	public static float HorizontalDistance(Vector3 a, Vector3 b) {
		return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.z - b.z, 2));
	}

}

[System.Serializable]
public struct Position {
	public int x, y;

	public Position(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public static Position operator+ (Position a, Position b) {
		return new Position(a.x + b.x, a.y + b.y);
	}
	public static Position operator* (Position a, int m) {
		return new Position(a.x * m, a.y * m);
	}

	public override string ToString() {
		return "x: " + x + ", y: " + y;
	}
}

public enum TerrainType {
	Mountains,
	Forest,
	Clearing,
	Coast,
	Shallows,
};
