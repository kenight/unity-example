using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public int maxCount = 4;

	public void OnPointerEnter(PointerEventData e) {
		if (!e.dragging)
			return;
		CardDraggable cd = e.pointerDrag.GetComponent<CardDraggable>();
		if (cd != null && this.transform.childCount < maxCount) {
			cd.placeHolder.SetParent(this.transform);
		}
	}

	public void OnPointerExit(PointerEventData e) { }

	public void OnDrop(PointerEventData e) {
		CardDraggable cd = e.pointerDrag.GetComponent<CardDraggable>();
		if (cd != null && this.transform.childCount < maxCount) {
			cd.placeHolder.SetParent(this.transform);
		}
	}

}