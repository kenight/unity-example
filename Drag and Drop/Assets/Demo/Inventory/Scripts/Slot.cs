using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler {

	private ItemPanel dragObject;
	private ItemPanel currentItem;

	// Called on the object where a drag finishes
	// 拖拽完成时停留位置的物体，将触发该函数
	// 重要：拖拽中的物体会阻挡射线，将影响射线检测停留物体，导致该函数不调用
	// 解决方法一：在被拖拽物体执行 OnBeginDrag 函数时，通过改变被拖拽物体上的 Canvas Group 组件的 Block Raycasts = false 来暂时屏蔽射线
	// 解决方法二：在被拖拽物体执行 OnBeginDrag 函数时，通过改变被拖拽物体上的 Image 组件的 raycastTarget = false 来暂时屏蔽射线
	public void OnDrop(PointerEventData data) {
		if (data.pointerDrag != null) {
			// data.pointerDrag 拖拽的物体
			dragObject = data.pointerDrag.GetComponent<ItemPanel>();
		}

		if (hasItem()) {
			// 改变当前物品到被拖拽物品的 Slot 中
			currentItem = GetCurrentItemPanel();
			currentItem.slot = dragObject.slot;
			currentItem.transform.SetParent(dragObject.slot.transform);
			currentItem.transform.position = dragObject.slot.transform.position;
			// 改变被拖拽物体到当前 Slot 中
			dragObject.slot = this;
		} else {
			// 修改 Item Panel 被拖拽到的新的 Slot
			dragObject.slot = this;
		}
	}

	// 判定是否已有物品
	bool hasItem() {
		return transform.childCount > 0;
	}

	// 获取当前 Slot 中已存储的 Item Panel
	ItemPanel GetCurrentItemPanel() {
		return GetComponentInChildren<ItemPanel>();
	}

}