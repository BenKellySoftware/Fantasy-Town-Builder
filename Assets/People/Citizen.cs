using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {
	
	public int rest = 50;
	private bool tired = false;
	public GameObject house;
	public GameObject job;
	private Transform target;
	private float tickSpeed = 1;
	private float tickCount = 0;
	void Start() {
		rest = 50;
	}
	// Update is called once per frame
	void Update() {
		if (job && Vector3.Distance(transform.position, target.position) < 1) {
			if (tickCount >= tickSpeed) {
				Debug.Log("Tick");
				if (rest <= 0) {
					if (house) {
						target = house.transform;
						tired = true;
					}
				} else if (tired) {
					rest += 5;
					if (rest >= 50) {
						target = job.transform;
						tired = false;
					}				
				} else {
					job.GetComponent<Building>().Work();
				}
				tickCount = 0;
			} else {
				tickCount += Time.deltaTime;
			}
		} else {
			transform.position = Vector3.MoveTowards(transform.position, target.position, tickSpeed * Time.deltaTime);
		}
	}
}
