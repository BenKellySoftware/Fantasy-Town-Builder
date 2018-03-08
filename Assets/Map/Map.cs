using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum TerrainTypes {
	Clearing,
	ForestEdge,
	Forest,
	Coast,
	Shore,
	Sea,
	Mountain,
	MountainSide
};

public class Map : MonoBehaviour {

	public int width = 10;
	public int height = 10;
	public Hex[,] hexes;
	public GameObject selectedBuilding;

	void Start () {
		hexes = new Hex[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				//Template terrain setup
				int terrain = (int)TerrainTypes.Clearing;
				if(x < 5) {
					terrain = (int)TerrainTypes.Shore;
				} if(x == 5) {
					terrain = (int)TerrainTypes.Coast;
				} if(y == 0) {
					terrain = (int)TerrainTypes.MountainSide;
				} if(x == 74 || y == 74) {
					terrain = (int)TerrainTypes.ForestEdge;
				}
				Hex hex = new Hex (x, y, terrain);
				hexes[x,y] = hex;
			}
		}
	}

	public Hex FindHex(int x, int y) {
		if (x < 0 || y < 0 || x >= width || y >= height) {
			return null;
		}
		return hexes[x, y];
	}

	public static Coordinates CoordsByWorldPos(Vector3 worldPos) {
		int x = Mathf.CeilToInt(worldPos.z + (worldPos.x / Mathf.Sqrt(3)) - 0.5f);
		int y = Mathf.CeilToInt(worldPos.z - (worldPos.x / Mathf.Sqrt(3)) - 0.5f);
		return new Coordinates(x, y);
	}
}

public struct Coordinates {
	public int x, y;
	public Coordinates(int x, int y) {
		this.x = x;
		this.y = y;
	}
}

public class Hex {
	public Coordinates pos;
	public int terrain;
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

	public Hex(int x, int y, int terrain) {
		this.pos = new Coordinates(x, y);
		this.terrain = terrain;
		this.building = null;
	}

	public Vector2 worldSpace {
		/*Using an Axil system with y at pos 1 and x at pos 2 (up and top right)
		  Each hex y adds one height unit to world y, while each hex x adds 3/4
		  width unit to world x, and half a height unit to world y.
		  The height to 3/4 width conversion is sqrt(3)/2, found via weird math.
		*/
		//get { return new Vector2((x * Mathf.Sqrt(3) / 2), y + x / 2f); }

		get { return new Vector2((pos.x - pos.y) * Mathf.Sqrt(3) / 2, (pos.y + pos.x) / 2f); }
	}

}