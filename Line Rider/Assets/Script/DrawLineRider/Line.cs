using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	List<Vector2> points;

	// 画线的逻辑, 原理就是动态设置 lineRenderer
	public void DrawLine(Vector2 newPos) {
		// 第一个点
		if (points == null) {
			points = new List<Vector2>();
			AddPoint(newPos);
			return;
		}

		// 超过一定的移动范围后，才增加新的点
		if (Vector2.Distance(points.Last(), newPos) > 0.3f) { // using System.Linq
			AddPoint(newPos);
		}
	}

	void AddPoint(Vector2 newPos) {
		points.Add(newPos);
		// 首先需要重置 lineRenderer position element 的数量
		lineRenderer.positionCount = points.Count;
		// 设置新增 element 的位置
		lineRenderer.SetPosition(points.Count - 1, newPos);
		// 重置 EdgeCollider2D 的坐标点数据
		if (points.Count > 1)
			edgeCol.points = points.ToArray();
	}
}