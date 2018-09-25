using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public GameObject islandObject;

	public int width = 50;
	public int height = 50;

	void Start() {
		Tuple islandPos;
		for (islandPos.x = 0; islandPos.x < width;) {
			int maxWidth = 0;
			for (islandPos.y = 0; islandPos.y < height;) {
				Island island = Instantiate(islandObject).GetComponent<Island>();

				// Set to be child
				island.transform.SetParent(transform);

				// Random spacing
				islandPos.x += Random.Range(-3, 3);

				island.Init(islandPos);

				// Space islands
				islandPos.y += island.height + Random.Range(6, 10);
				if (island.width > maxWidth) maxWidth = island.width;
			}
			islandPos.x += maxWidth + Random.Range(4, 8);
		}
	}
}
