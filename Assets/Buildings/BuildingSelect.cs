using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelect : MonoBehaviour {
	static int rotateSpeed = 20;
	public GameObject building;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
	}
}
