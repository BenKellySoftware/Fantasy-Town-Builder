using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject subMenu;

	public void OnPointerEnter(PointerEventData eventData) {
		print("enter");
		subMenu.SetActive(true);
		GetComponent<Image>().color = new Color32(0,0,0,200);
	}

	public void OnPointerExit(PointerEventData eventData) {
		print("exit");
		subMenu.SetActive(false);
		GetComponent<Image>().color = new Color32(0,0,0,100);
	}
}
