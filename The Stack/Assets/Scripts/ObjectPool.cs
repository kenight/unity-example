using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public GameObject obj;
	[Range(1, 1000)]
	public int size = 10;

	// 使用队列存储游戏对象<先进先出>
	Queue<GameObject> poolQueue;

	void Start() {
		poolQueue = new Queue<GameObject>();

		for (int i = 0; i < size; i++) {
			GameObject _obj = Instantiate(obj);
			_obj.transform.SetParent(transform);
			_obj.SetActive(false);
			// 向 Queue 的末尾添加一个对象
			poolQueue.Enqueue(_obj);
		}
	}

	public GameObject InstantiateFromPool(Vector3 position, Quaternion rotation) {
		if (poolQueue.Count == 0)
			return null;

		// 移除并返回在 Queue 的开头的对象
		GameObject _obj = poolQueue.Dequeue();
		_obj.transform.position = position;
		_obj.transform.rotation = rotation;
		_obj.SetActive(true);

		// 重新将 _obj 添加 Queue 的末尾，进行重用
		poolQueue.Enqueue(_obj);
		return _obj;
	}

}