using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 通过实现输入事件的相关接口(supported Event interface)并处理回调函数来控制拖拽
// 注意：使用挂载 Event Trigger 组件的方式不能传递 PointerEventData 参数
public class ItemPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Item item; // item 加入仓库后需要存储 item 信息，方便后续操作如，拖拽、交换
	public Slot slot; // 存储 Item 属于哪个 Slot

	void Start() {
		// 初始化
		gameObject.name = item.itemName;
		GetComponent<Image>().sprite = item.spriteRenderer.sprite;
	}

	public void OnBeginDrag(PointerEventData eventData) {
		if (item == null)
			return;

		// 开始拖拽时，置于 Slot 上，避免遮盖问题
		transform.SetParent(transform.parent.parent);
		// 开始拖拽时，暂时屏蔽掉射线检测，避免影响 OnDrop 的判断
		GetComponent<Image>().raycastTarget = false;
	}

	public void OnDrag(PointerEventData eventData) {
		if (item == null)
			return;

		// 跟随
		transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (item == null)
			return;

		// 回到 Slot 层级下
		transform.SetParent(slot.transform);
		// 回到原位上原位上
		transform.position = transform.parent.position;
		// 拖拽完成后恢复射线检测
		GetComponent<Image>().raycastTarget = true;
	}
}