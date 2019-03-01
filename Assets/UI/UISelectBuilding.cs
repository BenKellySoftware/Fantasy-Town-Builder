using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UISelectBuilding : MonoBehaviour, IPointerClickHandler {
	public Building building;
	public void OnPointerClick(PointerEventData eventData) {
		Controls.selectedBuilding = building;
	}
}