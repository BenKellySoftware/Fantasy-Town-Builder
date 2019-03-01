using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIList : UIInterface
{
	public Options options;
	private Options comparison;

  // Redraws the positions
	void Update() {
		if (!options.Equals(comparison)) {
			Calculate();
			comparison = options;
		}
	}

  private void Calculate() {
		RectTransform rect = GetComponent<RectTransform>();
		int dir;

		if (options.direction == Align.Top || options.direction == Align.Bottom) {
			if (options.direction == Align.Top) {
				dir = -1;
				rect.anchorMin = new Vector2(rect.anchorMin.x, 1);
				rect.anchorMax = new Vector2(rect.anchorMax.x, 1);
			} else {
				dir = 1;
				rect.anchorMin = new Vector2(rect.anchorMin.x, 0);
				rect.anchorMax = new Vector2(rect.anchorMax.x, 0);
			}

			float offset = -options.padding;
			foreach (RectTransform item in options.items) {
				offset -= (item.rect.height/2);
				item.anchorMin = new Vector2(0.5f, 1);
				item.anchorMax = new Vector2(0.5f, 1);
				item.sizeDelta = new Vector2(rect.rect.width - 2 * options.padding, item.sizeDelta.y);
				item.anchoredPosition = new Vector2(0, offset);
				offset -= options.itemPadding + item.rect.height/2;
			}
			offset -= options.padding - options.itemPadding;
			rect.sizeDelta = new Vector2(rect.sizeDelta.x, Mathf.Abs(offset));
			rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, dir * offset/2);
		}
  }

	public enum Align {
		Top,
		Bottom,
		Left,
		Right,

	}

	[System.Serializable]
	public struct Options {
		[Range(0, 50)]
		public int padding; // Padding around all objects
		[Range(0, 50)]
		public int itemPadding; // Padding between objects
		public bool fillScreen; //Check to stretch the menu the full screen width
		public Align direction; // Which position the list starts and moves in.
		public Align position;
		public List<RectTransform> items;
	}
}
