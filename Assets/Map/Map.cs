using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public GameObject islandObject;

	public int width = 20;
	public int height = 20;

	void Start () {
		Coordinates islandPos;
		for (islandPos.x = 0; islandPos.x < width; islandPos.x += 4) {
			for (islandPos.y = 0; islandPos.y < height; islandPos.y += 4) {
				Island island = Instantiate(islandObject).GetComponent<Island>();
				//Set to be child
				island.transform.SetParent(transform);
				island.Init(islandPos);
			}
		}
	}
}
