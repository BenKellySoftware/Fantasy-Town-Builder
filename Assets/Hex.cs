using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct Coordinates {
	public int x, y;
	public Coordinates(int x, int y) {
		this.x = x;
		this.y = y;
	}
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

public class Hex : MonoBehaviour {
	public Coordinates pos;
	public TerrainType terrain;
	public GameObject building;

	public Hex[] neighbours {
		get {
			Map map = GameObject.Find("Map").GetComponent<Map>();
			return new Hex[] {
				map.FindHex(pos.x + 1, pos.y + 1),
				map.FindHex(pos.x + 1, pos.y),
				map.FindHex(pos.x, pos.y - 1),
				map.FindHex(pos.x - 1, pos.y - 1),
				map.FindHex(pos.x - 1, pos.y),
				map.FindHex(pos.x, pos.y + 1)
			};
		}
	}

	public void Init(int x, int y, TerrainType terrain) {
		this.pos = new Coordinates(x, y);
		this.terrain = terrain;
		this.building = null;
		/*Using an Axil system with y at pos 1 and x at pos 2 (up and top right)
		  Each hex y adds one height unit to world y, while each hex x adds 3/4
		  width unit to world x, and half a height unit to world y.
		  The height to 3/4 width conversion is sqrt(3)/2, found via weird math.
		*/
		transform.position = new Vector3((this.pos.x - this.pos.y) * Mathf.Sqrt(3), 0, (this.pos.y + this.pos.x));
	}
}
