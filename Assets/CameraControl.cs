using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	[Range(1, 100)]
	public int moveSpeed = 2;
	public int scrollSpeed  = 10;

	private Rigidbody rb;
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 acceleration = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * moveSpeed * 2, Input.GetAxis("Vertical") * moveSpeed / Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.x), (Input.GetAxis("Zoom") * scrollSpeed) + (Input.GetAxis("Vertical") * moveSpeed / Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.x))));
		transform.eulerAngles += new Vector3(0,Input.GetAxis("Camera Rotate"),0);
		rb.AddForce(acceleration);
	}
}
