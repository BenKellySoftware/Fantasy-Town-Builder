using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour {

	[Range(1, 100)]
	public int moveSpeed = 2;
	[Range(1, 100)]
	public int scrollSpeed  = 10;

	public GameObject cursor;
	public Map map;
	private static Rigidbody rb;
	private static Camera mainCamera;

	private static Building _selectedBuilding;
	public static Building selectedBuilding {
		get { return _selectedBuilding; }
		set { 
			Debug.Log("Selecting " + value.name);
			if (_selectedBuilding) {
				Destroy(_selectedBuilding);
			}
			_selectedBuilding = Instantiate(value.gameObject, new Vector3(-100, -100, -100), Quaternion.identity).GetComponent<Building>();
			_selectedBuilding.name = value.name;
		}
	}

	void Start() {
		//cursor = GameObject.Find("Cursor");
		//map = GameObject.Find("Map").GetComponent<Map>();
		rb = GetComponent<Rigidbody>();
		mainCamera = GetComponent<Camera>();
	}
	
	void Update() {
		// Camera Movement
		Vector3 acceleration = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * moveSpeed * 2, Input.GetAxis("Vertical") * moveSpeed / Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.x), (Input.GetAxis("Zoom") * scrollSpeed * 100) + (Input.GetAxis("Vertical") * moveSpeed / Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.x))));
		transform.eulerAngles += new Vector3(0,Input.GetAxis("Camera Rotate"),0);
		rb.AddForce(acceleration);

		if (Input.GetButtonDown("Cancel")) {
			if (selectedBuilding != null) {
				Destroy(selectedBuilding);
			}
		}

		if (EventSystem.current.IsPointerOverGameObject()) {
			cursor.SetActive(false);
			return;
		}

		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			Hex hex = hit.collider.GetComponent<Hex>();
			if (hex != null) {
				cursor.SetActive(true);
				cursor.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + 1.45f, hex.transform.position.z);

				if (selectedBuilding != null) {
					selectedBuilding.Place(hex);
				} else if (Input.GetMouseButtonDown(0)) { //Select tile for ui info
					GameObject.Find("Little Lad").GetComponent<Citizen>().StartCoroutine("Travel", hex);
				}

			} else { // Not on hex
				cursor.SetActive(false);
			}
		}

		/* Swap with a UI ray hit
		// Click on a building selector
		if (hit.collider.CompareTag("Selector") && Input.GetMouseButtonDown(0)) {
			hit.collider.GetComponent<BuildingSelect>().Select();
		}*/
	}
}
