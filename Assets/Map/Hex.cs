using System;
using UnityEngine;

[Serializable]
public class Hex : MonoBehaviour {
	public Material[] TERRAIN_MATERIALS;

	public Position pos;
	public float altitude;
	public GameObject building;

	public TerrainType terrain;
	private Island island;

	// Used for pathfinding
	public Hex cameFrom;
	public int distanceFrom;
	public int distanceTo;

	//Requires to be parented by an island
	public void Init(Position pos, float altitude) {
		this.pos = pos;
		this.altitude = altitude;
		this.building = null;
		this.island = transform.parent.GetComponent<Island>();

		if (altitude < 0) {
			this.Terrain = TerrainType.Shallows;
		} else if (altitude < 0.1f) {
			this.Terrain = TerrainType.Coast;
		} else if (altitude < 0.8f) {
			this.Terrain = TerrainType.Clearing;
		} else if (altitude < 1.6f) {
			this.Terrain = TerrainType.Forest;
		} else {
			this.Terrain = TerrainType.Mountains;
		}

		/*Using an Axil system with y at pos 1 and x at pos 2 (up and top right)
		  Each hex y adds one height unit to world y, while each hex x adds 3/4
		  width unit to world x, and half a height unit to world y.
		  The height to 3/4 width conversion is sqrt(3)/2, found via weird math.
		*/
		transform.localPosition = new Vector3((this.pos.x - this.pos.y) * Mathf.Sqrt(3), altitude - 1.45f, (this.pos.y + this.pos.x));
	}

	//Returns the neighbour in any direction
	public Hex FindNeighbour(int axis) {
		return island.FindHex(new Position(pos.x + Map.AXIS_OFFSET[axis].x, pos.y + Map.AXIS_OFFSET[axis].y));
	}

	public Position gloabalPos {
		get { 
			return new Position {
				x = transform.parent.GetComponent<Island>().Pos.x + pos.x,
				y = transform.parent.GetComponent<Island>().Pos.y + pos.y
			};
		}
	}

	public TerrainType Terrain {
		get { return terrain; }
		set { 
			this.terrain = value;
			GetComponent<Renderer>().material = TERRAIN_MATERIALS[(int)this.terrain];
		}
	}
}
