using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public PlayerInvDataScriptable playerInvData;
	public ItemPanel itemPanelPrefab;
	public Slot[] slots;

	void Awake() {
		slots = GetComponentsInChildren<Slot>();
	}

	void Start() {
		InitPlayerInv();
	}

	// 从 playerInvData 中读取背包数据并显示到背包中
	void InitPlayerInv() {
		foreach (Item item in playerInvData.data) {
			AddItemPanelToSlot(FindEmptySlot(), item);
		}
	}

	// 从所有 Slot 的列表中获取空的 Slot
	Slot FindEmptySlot() {
		for (int i = 0; i < slots.Length; i++) {
			if (slots[i].transform.childCount == 0)
				return slots[i];
		}
		return null;
	}

	// 创建新的 Item Panel 并加到 Slot 中
	void AddItemPanelToSlot(Slot slot, Item item) {
		// Clone Item Panel
		ItemPanel itemPanel = Instantiate(itemPanelPrefab);
		// 将 Item Panel 放到 Slot 下 (层级关系)
		itemPanel.transform.SetParent(slot.transform);
		// 设置 Item Panel 的 position
		itemPanel.transform.position = slot.transform.position;
		// 存储 itemPanel 信息
		itemPanel.item = item;
		itemPanel.slot = slot;
	}

	// 为仓库增添一个新物品
	// saved:是否新增数据到 playerInvItems 中
	public bool AddNewItem(Item item) {
		// 找一个空 Slot index
		Slot slot = FindEmptySlot();
		// 如果有空的 Slot，则新 Item Panel 加到 Slot 中
		if (slot) {
			AddItemPanelToSlot(slot, item);
			// 添加新 item 到数据存储中
			playerInvData.data.Add(item);
			return true;
		}
		return false;
	}

}