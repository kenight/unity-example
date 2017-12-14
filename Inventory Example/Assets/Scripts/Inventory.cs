using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public PlayerInvItems playerInvItems;
	public Slot[] slots;

	void Awake() {
		slots = GetComponentsInChildren<Slot>();
	}

	void Start() {
		InitPlayerInv();
	}

	// 从 PlayerInvItems ScriptableObject 中读取背包数据并显示到背包中
	void InitPlayerInv() {
		foreach (Item item in playerInvItems.items) {
			AddItemToInv(item);
		}
	}

	// 获取空的 Slot
	public Slot GetEmptySlot() {
		for (int i = 0; i < slots.Length; i++) {
			if (slots[i].empty)
				return slots[i];
		}
		return null;
	}

	// 将 Item 显示到背包中
	public void AddItemToInv(Item item) {
		// 获取一个空 Slot
		Slot slot = GetEmptySlot();

		// 获取 Slot 下的 Item 上的 Image 组件
		ItemPanel itemPanel = slot.GetComponentInChildren<ItemPanel>();

		// 存储 itemPanel 信息
		itemPanel.item = item;
		itemPanel.slot = slot;

		// 设置 Image sprite
		itemPanel.GetComponent<Image>().sprite = item.spriteRenderer.sprite;

		// 启用 Image ，默认是关闭的
		itemPanel.GetComponent<Image>().enabled = true;

		// 最后改变 Slot 状态为非空
		slot.empty = false;
	}

}