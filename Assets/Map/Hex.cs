using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Hex : MonoBehaviour {
	public Coordinates pos;
	public TerrainType terrain;
	public GameObject building;

	public Hex[] neighbours {
		get {
			Island island =  transform.parent.GetComponent<Island>();
			return new Hex[] {
				island.FindHex(pos.x + 1, pos.y + 1),
				island.FindHex(pos.x + 1, pos.y),
				island.FindHex(pos.x, pos.y - 1),
				island.FindHex(pos.x - 1, pos.y - 1),
				island.FindHex(pos.x - 1, pos.y),
				island.FindHex(pos.x, pos.y + 1)
			};
		}
	}

	public void Init(Coordinates pos, TerrainType terrain) {
		this.pos = pos;
		this.terrain = terrain;
		this.building = null;
		/*Using an Axil system with y at pos 1 and x at pos 2 (up and top right)
		  Each hex y adds one height unit to world y, while each hex x adds 3/4
		  width unit to world x, and half a height unit to world y.
		  The height to 3/4 width conversion is sqrt(3)/2, found via weird math.
		*/
		transform.localPosition = new Vector3((this.pos.x - this.pos.y) * Mathf.Sqrt(3), 0, (this.pos.y + this.pos.x));
	}
}
