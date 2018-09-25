using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	private Camera mainCamera;

	public Map map;
	public GameObject selectedBuilding;

	// Use this for initialization
	void Start() {
		mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update() {
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			// A hex is hit while placing a building
			if (hit.collider.GetComponent<Hex>() != null && selectedBuilding != null) {
				selectedBuilding.GetComponent<Building>().Place(hit.collider.GetComponent<Hex>());
			}
			// Click on a building selector
			else if (hit.collider.CompareTag("Selector") && Input.GetMouseButtonDown(0)) {
				hit.collider.GetComponent<BuildingSelect>().Select();
			}
		}
	}
}
