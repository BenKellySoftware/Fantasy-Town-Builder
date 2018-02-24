using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	[Range(1, 20f)]
	public int moveSpeed = 2;
	public int scrollSpeed  = 10;

	private Rigidbody rb;
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
		//Vector3 velocity = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * transform.position.y, -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, Input.GetAxis("Vertical") * transform.position.y));
		Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * transform.position.y, -Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, Input.GetAxis("Vertical") * transform.position.y);

		//if (acceleration.magnitude > 1) {
		//	acceleration.Normalize();
		//}
		rb.velocity = velocity;
	}
}
