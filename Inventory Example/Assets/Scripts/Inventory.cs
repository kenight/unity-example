using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject slotPrefab;
	public GameObject slotPanel;

	private List<GameObject> slots = new List<GameObject>();

	void Start() {
		InitInventory();
	}

	void Update() {

	}

	void InitInventory() {
		for (int i = 0; i < 20; i++) {
			slots.Add(Instantiate(slotPrefab));
			slots[i].transform.SetParent(slotPanel.transform);
		}
	}

	public void AddItemToInventory() {

	}
}