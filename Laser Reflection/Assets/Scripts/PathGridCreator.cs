using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGridCreator : MonoBehaviour {

	public int rows = 5;
	public int cols = 5;
	public float size = 1f;
	public GameObject PathPointPrefab;

	void Start() {
		for (int x = 0; x < rows; x++) {
			for (int y = 0; y < cols; y++) {
				Vector2 pos = GetCellPos(x, y);
				GameObject pathPoint = Instantiate(PathPointPrefab, pos, Quaternion.identity, transform);
				pathPoint.name = "Point " + x + " " + y;
			}
		}
	}

	Vector2 GetCellPos(int x, int y) {
		float offsetX = (rows - 1) * size / 2 + transform.position.x;
		float offsetY = (cols - 1) * size / 2 + transform.position.y;
		return new Vector2(x * size - offsetX, y * size - offsetY);
	}
}