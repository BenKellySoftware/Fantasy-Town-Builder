using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities {
	public const float ALTITUDE_MAX = 2f;
	public const float ALTITUDE_DIFF_MAX = 0.3f;

	public static Map map {
		get {
			return GameObject.Find("Map").GetComponent<Map>();
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
	DeepForest, // Unscouted areas 
	Forest, // Forrest edge or scouted areas
	Mountains,
	Clearing,
	Coast,
	Shallows,
};

public enum GameSpeed {
	Pause = 0,
	Normal = 1,
	Fast = 2
}
