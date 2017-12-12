using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// 接受 api 返回的 json 数据
[System.Serializable]
public class ItemData {

	public List<Item> data;
	public int total;

	public static ItemData get() {
		string jsonString = File.ReadAllText(Application.dataPath + "/Data/ItemJsonFromApi.json");
		return JsonUtility.FromJson<ItemData>(jsonString);
	}

}