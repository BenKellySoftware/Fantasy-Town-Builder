using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
	public GameObject hexObject;

	public Tuple pos;
	public Hex[,] hexes;
	public int width, height;

	public void Init(Tuple pos) {
		this.pos = pos;
		transform.localPosition = new Vector3((pos.x - pos.y) * Mathf.Sqrt(3), 0, (pos.y + pos.x));
		width = Random.Range(5, 10);
		height = Random.Range(5, 10);
		hexes = new Hex[width, height];

		Tuple hexPos;
		for (hexPos.x = 0; hexPos.x < width; hexPos.x++) {
			for (hexPos.y = 0; hexPos.y < height; hexPos.y++) {
				if (hexPos.y - hexPos.x <= height/2 && hexPos.x - hexPos.y <= width/2) { // Cut off corners
					Hex hex = Instantiate(hexObject).GetComponent<Hex>();
					//Set to be child
					hex.transform.SetParent(transform);

					hex.Init(hexPos, TerrainType.Clearing);
					hexes[hexPos.x,hexPos.y] = hex;
				}
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
