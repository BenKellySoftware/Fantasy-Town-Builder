using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {

	// TODO: Replace these vars with a list that can be iterated over instead;
	public int rest = 50; //Rest at a house if assinged, a tavern, or gives a tiredness penalty if empty
	//private int happiness = 50; //Go to entertainment when empty, rate dropped based on adventurer activity
	//private int hunger = 50;
	public int statThreshold = 10; //How low any of the stats can get before treating

	public int gold;

	//private bool discontent = false; //Triggers if any meter gets too low, lowers productivity
	public Hex position; // Current position based on hex co-ordinates
	private float tickSpeed = 1f; // How often a tick occurs

	public Building home;
	public Building job;
	private Building target; //The building currently being operated on


	public AnimationCurve squashAndStretch;
	public AnimationCurve headAndHat;
	public AnimationCurve jumpUp;
	public AnimationCurve jumpDown;

	private List<Hex> path; // The path someone takes to get 

	public Inventory inventory;

	void Start() {
		rest = 50;
	}

	IEnumerator Travel(Hex destination) {
		List<Hex> path = GameObject.Find("Map").GetComponent<Map>().Pathfind(position, destination);
		foreach (Hex hex in path) {
			//Move to the next hex in the list
			transform.LookAt(hex.transform);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y); //Only set the y rotation
			//MOVE_HEX_ANIM.Play();
			float jumpDiff = hex.altitude - position.altitude;
			float distance = 2;
			do { // Travels 2 units each hex, so e
				transform.Translate(new Vector3(0,0,2*Time.deltaTime*tickSpeed));// Move 1 hex per tickspeed
				distance = Utilities.HorizontalDistance(transform.position, hex.transform.position);
				float scale = squashAndStretch.Evaluate(1 - distance / 2) * Mathf.Abs(jumpDiff) / 2;
				transform.localScale = new Vector3(1 + scale, 1 - scale ,1 + scale);
				float height = headAndHat.Evaluate(1 - distance / 2) * Mathf.Abs(jumpDiff) / 2;
				transform.Find("Hat").localPosition = new Vector3(0,0.34f + height,0);
				transform.Find("Head").localPosition = new Vector3(0,0.26f + height/2,0);
				float jump;
				if (jumpDiff > 0) {
					jump = jumpDiff * jumpUp.Evaluate(1-distance/2);
				} else {
					jump = -jumpDiff * jumpDown.Evaluate(1-distance/2);
				}
				transform.position = new Vector3(transform.position.x, position.altitude + jump, transform.position.z);

				yield return null;			
			} while(distance > 0.1f);
			position = hex;
		}
		//StartCoroutine("UseBuilding");
	}

	IEnumerator UseBuilding() {
		while (rest > statThreshold) {
			target.Use(this);
			yield return new WaitForSeconds(tickSpeed);
		}
		target = home;
		StartCoroutine("Travel"); //Start heading back home for rest
	}
}
