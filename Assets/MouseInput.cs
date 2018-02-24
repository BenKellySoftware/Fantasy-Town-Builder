using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	private Camera mainCamera;

	public Map map;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
			if (hit.collider.CompareTag("Terrain") && map.selectedBuilding != null) {
				map.PlaceBuilding(hit.point);
			} else if (hit.collider.CompareTag("Selector") && Input.GetMouseButtonDown(0)) {
				Debug.Log("Select");
				if (map.selectedBuilding) {
					Destroy(map.selectedBuilding);
				}
				map.selectedBuilding = Instantiate(hit.collider.GetComponent<BuildingSelect>().building);
			}
		}
	}
}