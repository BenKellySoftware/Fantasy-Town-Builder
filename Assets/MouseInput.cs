using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	private Camera mainCamera;
	public GameObject cursor;

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
			if (hit.collider.GetComponent<Hex>() != null) {
				cursor.SetActive(true);
				Hex hex = hit.collider.GetComponent<Hex>();
				cursor.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + 1.45f, hex.transform.position.z);
				if (selectedBuilding != null) {
					selectedBuilding.GetComponent<Building>().Place(hex);
				} else if (Input.GetMouseButtonDown(0)) {
					GameObject.Find("Little Lad").GetComponent<Citizen>().StartCoroutine("Travel", hex);
				}
			} else {
				cursor.SetActive(false);
			}
			// Click on a building selector
			if (hit.collider.CompareTag("Selector") && Input.GetMouseButtonDown(0)) {
				hit.collider.GetComponent<BuildingSelect>().Select();
			}
		}
	}
}
