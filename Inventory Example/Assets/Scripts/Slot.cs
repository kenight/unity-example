using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

	public int id;
	public bool empty = true;

	// Called on the object where a drag finishes
	// 拖拽完成时停留位置的物体，将触发该函数
	// 重要：拖拽中的物体会阻挡射线，将影响射线检测停留物体，导致该函数不调用
	// 解决：在被拖拽物体执行 OnBeginDrag 函数时，通过改变被拖拽物体上的 Canvas Group 组件的 Block Raycasts = false 来暂时屏蔽射线
	public void OnDrop(PointerEventData data) {
		if (data.pointerDrag != null) { // data.pointerDrag 拖拽的物体
			Debug.Log("Dropped object was: " + data.pointerDrag);
		}
	}

}