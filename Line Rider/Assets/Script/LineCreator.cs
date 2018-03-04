using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	public GameObject line;
	Line current;

	void Update() {
		// 左键按下：创建 Line gameobject
		if (Input.GetMouseButtonDown(0)) {
			GameObject lineGO = Instantiate(line);
			current = lineGO.GetComponent<Line>();
		}

		// 鼠标移动：画线
		if (current != null) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			current.DrawLine(mousePos);
		}

		// 左键释放：停止画线
		if (Input.GetMouseButtonUp(0)) {
			current = null;
		}
	}
}