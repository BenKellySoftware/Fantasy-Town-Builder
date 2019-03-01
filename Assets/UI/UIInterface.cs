using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInterface : MonoBehaviour {
	public void Toggle() {
		Debug.Log("Click");
		gameObject.SetActive(!gameObject.activeSelf);
	}
}
