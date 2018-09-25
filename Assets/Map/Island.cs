using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
	public GameObject hexObject;

	public Coordinates pos;
	public Hex[,] hexes;
	public int width = 3;
	public int height = 3;

	public void Init (Coordinates pos) {
		this.pos = pos;
		transform.localPosition = new Vector3((pos.x - pos.y) * Mathf.Sqrt(3), 0, (pos.y + pos.x));

		hexes = new Hex[width, height];
		Coordinates hexPos;
		for (hexPos.x = 0; hexPos.x < width; hexPos.x++) {
			for (hexPos.y = 0; hexPos.y < height; hexPos.y++) {
				//Template terrain setup
				TerrainType terrain = TerrainType.Clearing;
				if(hexPos.x < 5) {
					terrain = TerrainType.Shore;
				} if(hexPos.x == 5) {
					terrain = TerrainType.Coast;
				} if(hexPos.y == 0) {
					terrain = TerrainType.MountainSide;
				} if(hexPos.x == 74 || hexPos.y == 74) {
					terrain = TerrainType.ForestEdge;
				}
				Hex hex = Instantiate(hexObject).GetComponent<Hex>();
				//Set to be child
				hex.transform.SetParent(transform);

				hex.Init(hexPos, terrain);
				hexes[hexPos.x,hexPos.y] = hex;
			}
		}
	}

	public Hex FindHex(int x, int y) {
		if (x < 0 || y < 0 || x >= width || y >= height) {
			return null;
		}
		return hexes[x, y];
	}
}
