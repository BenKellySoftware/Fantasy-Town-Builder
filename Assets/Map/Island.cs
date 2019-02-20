using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {
	public GameObject HEX_OBJECT;

	//The max distance any one hex is from the centre, set during init
	public int radius;
	//2D Array of hexes in the island, index offset up by radius
	public Hex[,] hexes;

	//Position of island centre relative to the map
	private Position pos;
	public Position Pos {
		get { return pos; }
		set {
			this.pos.x = value.x;
			this.pos.y = value.y;
			transform.localPosition = new Vector3((pos.x - pos.y) * Mathf.Sqrt(3), 0, (pos.y + pos.x));
		}
	}

	public void Init(Position pos, int radius) {
		this.Pos = pos;
		this.radius = radius;

		float altitude = 2;
		hexes = new Hex[radius*2+1, radius*2+1];

		hexes[radius, radius] = Instantiate(HEX_OBJECT).GetComponent<Hex>();
		hexes[radius, radius].transform.SetParent(transform);
		hexes[radius, radius].Init(new Position(0,0), altitude);

		for (int ring = 1; ring <= radius; ring++) {
			for (int i = 0; i < 6; i++) { //Each spoke
				Position hexPos = Map.AXIS_OFFSET[i] * ring;
				for (int j = 0; j < ring; j++) { //Fill out the ring by drawing around the spokes
					if (j != 0) {
						hexPos += Map.AXIS_OFFSET[(i + 2) % 6]; // Move across to the next hex in the ring
					}
					//Base the altitude off of the closest inner ring hex
					Hex innerHex1 = FindHex(hexPos + Map.AXIS_OFFSET[(i + 3) % 6]); //Find inner ring for its altitude
					if (!innerHex1) continue;

					if (j==0) { //Can only check 1 if on spoke, but both otherwise
						if(innerHex1.altitude < 0f) continue; //Only create if not already submerged
						altitude = innerHex1.altitude - Random.Range(0f, 0.4f);
					} else {
						Hex innerHex2 = FindHex(hexPos + Map.AXIS_OFFSET[(i + 4) % 6]); //Find inner ring for its altitude
						if (!innerHex2) continue;
						if(innerHex1.altitude < 0f && innerHex2.altitude < 0f) continue; //Only create if not already submerged

						altitude = (innerHex1.altitude + innerHex2.altitude)/2 - Random.Range(0f, 0.3f);
					}
					hexes[radius + hexPos.x, radius + hexPos.y] = Instantiate(HEX_OBJECT).GetComponent<Hex>();
					hexes[radius + hexPos.x, radius + hexPos.y].transform.SetParent(transform);
					hexes[radius + hexPos.x, radius + hexPos.y].Init(hexPos, altitude);
				}
			}
		}
	}

	//Returns hex at relative co-ordinate, first checking it's withing the islands bounds
	public Hex FindHex(Position pos) {
		if (pos.x < -radius || pos.y < -radius || pos.x > radius || pos.y > radius) {
			return null;
		}
		return hexes[radius+pos.x, radius+pos.y];
	}
}