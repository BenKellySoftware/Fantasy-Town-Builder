using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour {
	public static readonly Position[] AXIS_OFFSET = {
		new Position( 1,  1),
		new Position( 1,  0),
		new Position( 0, -1),
		new Position(-1, -1),
		new Position(-1,  0),
		new Position( 0,  1)
	};

	public GameObject ISLAND_OBJECT;

	public int size = 10;

	public int islandSpacingMin = 5;
	public int islandSpacingMax = 10;
	public List<Island> islands;

	public MapType mapType;
	public enum MapType {
		Islands,
		Continent,
		Pregen
	};

	void Start() {
		switch (mapType) {
		case MapType.Islands:
			GenIslands();
			break;
		case MapType.Continent:
			GenContinent();
			break;
		case MapType.Pregen:
			LoadMap();
			break;
		}
	}

	private void GenIslands() {
		Island island = Instantiate(ISLAND_OBJECT).GetComponent<Island>();
		island.name = ISLAND_OBJECT.name;
		island.transform.SetParent(transform);
		island.Init(new Position(0,0), 20);
		islands.Add(island);
		/*for (int ring = 1; ring <= radius; ring++) {

				// Set to be child
				island.transform.SetParent(transform);

				// Random spacing
				islandPos.x += Random.Range(-3, 3);

				int radius = 
				island.Init(new Position(islandPos.x, islandPos.y), Random.Range(6, 20));

				// Space islands
				islandPos.y += island.radius*2 + Random.Range(6, 10);
			}
			islandPos.x += island.radius*2 + Random.Range(4, 8);
		}*/
	}

	private void GenContinent() {
		//TODO
	}

	private void LoadMap() {
		//TODO
	}

	//Finds and returns the fastest to travel to get to the final destination
	//Position is a hex because it's fixed, but destination is the building because it could potentially be multiple hexes.
	//TODO: All of this
	//TODO: Also determine which hex in a building is closest and navigate there.
	public List<Hex> Pathfind(Hex origin, Hex destination)
	{
		List<Hex> frontier = new List<Hex>();
		frontier.Add(origin);

		for (int i = 0; i < frontier.Count; ++i)
		{
			if (frontier[i] == destination) {
				var path = new List<Hex>();
				var current = frontier[i];
				while (current != origin) {
					path.Add(current);
					current = current.cameFrom;
				}
				path.Add(current);
				path.Reverse();
				return path;
			}

			for (int j = 0; j < 6; j++) { //Each neighbour
				Hex neighbour = islands[0].FindHex(frontier[i].pos + Map.AXIS_OFFSET[j]);

				if (neighbour != null && !frontier.Contains(neighbour)) {
					neighbour.cameFrom = frontier[i];
					neighbour.distanceFrom = frontier[i].distanceFrom + 1;
					neighbour.distanceTo = GetDistance(neighbour.pos, destination.pos);
					frontier.Add(neighbour);
				}
			}
			frontier = frontier.OrderBy(x => x.distanceFrom + x.distanceTo).ThenBy(x => x.distanceFrom).ToList();
		}
		return null; // Can't find a path
	}

	public int GetDistance(Position a, Position b) {
		return Mathf.Max(Mathf.Abs(a.x - b.x), Mathf.Abs(a.y - b.y));
	}
}