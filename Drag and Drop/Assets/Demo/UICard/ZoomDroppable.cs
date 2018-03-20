using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	Color originColor;

	void Start() {
		originColor = GetComponent<Image>().color;
	}

	public void OnPointerEnter(PointerEventData e) {
		if (e.dragging) {
			Color c = GetComponent<Image>().color;
			c.a = 0.5f;
			GetComponent<Image>().color = c;
		}
	}
	public void OnPointerExit(PointerEventData e) {
		if (e.dragging) {
			GetComponent<Image>().color = originColor;
		}
	}

	public void OnDrop(PointerEventData e) {
		CardDraggable cd = e.pointerDrag.GetComponent<CardDraggable>();
		if (cd != null) {
			cd.parentToReturn = this.transform;
		}
		GetComponent<Image>().color = originColor;
	}

}