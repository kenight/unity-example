using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveItem : MonoBehaviour, IDropHandler {

	public PlayerInvDataScriptable playerInvData;
	private ItemPanel dragObject;

	public void OnDrop(PointerEventData data) {
		if (data.pointerDrag != null) {
			dragObject = data.pointerDrag.GetComponent<ItemPanel>();
		}
		dragObject.slot = null;
		playerInvData.data.Remove(dragObject.item);
		Destroy(dragObject.gameObject);
	}
}