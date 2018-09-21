using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Map : MonoBehaviour {
	public GameObject hexObject;

	public int width = 10;
	public int height = 10;
	public Hex[,] hexes;

	void Start () {
		hexes = new Hex[width, height];
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				//Template terrain setup
				TerrainType terrain = TerrainType.Clearing;
				if(x < 5) {
					terrain = TerrainType.Shore;
				} if(x == 5) {
					terrain = TerrainType.Coast;
				} if(y == 0) {
					terrain = TerrainType.MountainSide;
				} if(x == 74 || y == 74) {
					terrain = TerrainType.ForestEdge;
				}
				Hex hex = Instantiate(hexObject).GetComponent<Hex>();
				hex.Init(x, y, terrain);
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
