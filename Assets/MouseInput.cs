using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	private Camera mainCamera;

	public Map map;
	public GameObject selectedBuilding;

	// Use this for initialization
	void Start () {
		mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			if (hit.collider.CompareTag("Terrain") && selectedBuilding != null) {
				selectedBuilding.GetComponent<Building>().Place(hit.point);
			} else if (hit.collider.CompareTag("Selector") && Input.GetMouseButtonDown(0)) {
				hit.collider.GetComponent<BuildingSelect>().Select();
			}
		}
	}
}