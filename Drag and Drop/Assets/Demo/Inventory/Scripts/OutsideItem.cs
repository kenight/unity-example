using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutsideItem : MonoBehaviour, IPointerClickHandler {

	public Item item;
	public Inventory inventory;

	public void OnPointerClick(PointerEventData pointerEventData) {
		bool result = inventory.AddNewItem(item);
		if (result)
			Destroy(gameObject);
		else
			Debug.Log("没有更多的 Slot 了");
	}

}