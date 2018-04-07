using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TheStackPool : MonoBehaviour {

	public GameObject stackObj;
	public int size = 15;

	public static TheStackPool instance;
	[HideInInspector]
	public List<GameObject> theStack; // 每次移除将列表中最后一个位置的 stack 移动到列表第一个位置并重新赋值它的 posistion

	void Awake() {
		instance = this;
		InitStack();
	}

	void InitStack() {
		theStack = new List<GameObject>();
		for (int i = 0; i < size; i++) {
			GameObject _obj = Instantiate(stackObj);
			_obj.transform.SetParent(transform);
			_obj.transform.position = new Vector3(0, -i * _obj.GetComponent<Stack>().SingleHeight(), 0);
			theStack.Add(_obj);
		}
	}

	// 获取并返回最后一个元素，并将它移动到列表第一个位置
	public GameObject ReuseStack() {
		GameObject _obj = theStack.Last();
		theStack.RemoveAt(theStack.Count - 1);
		theStack.Insert(0, _obj);
		return _obj;
	}

	public GameObject FirstStack() {
		// using System.Linq
		return theStack.First();
	}

	public GameObject LastStack() {
		// using System.Linq
		return theStack.Last();
	}
}