using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public static readonly Position[] AXIS_OFFSET = {
		new Position( 1,  1),
		new Position( 1,  0),
		new Position( 0, -1),
		new Position(-1, -1),
		new Position(-1,  0),
		new Position( 0,  1)
	};

	public GameObject islandObject;

	public int size = 10;

	public int islandSpacingMin = 5;
	public int islandSpacingMax = 10;

	void Start() {
		Position islandPos;
		Island island = Instantiate(islandObject).GetComponent<Island>();
		island.transform.SetParent(transform);
		island.Init(new Position(0,0), 20);

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
}
