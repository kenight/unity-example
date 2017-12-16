using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour {

	void Start() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		// 注意：这个 Mesh 的顶点坐标使用 1，意味着比系统默认(0.5)的 Cube 大一倍
		Vector3[] vertices = {

			// front face
			new Vector3(1, -1, 1), // 顶点 0 左下
			new Vector3(-1, -1, 1), // 顶点 1 右下
			new Vector3(1, 1, 1), // 顶点 2 左上
			new Vector3(-1, 1, 1) // 顶点 3 右上
		};

		int[] triangles = {
			// front face
			0,
			2,
			3,
			0,
			3,
			1
		};

		Vector2[] uvs = {
			// 0,0 是 uv 坐标的 左下角
			// 1,1 是 uv 坐标的 右上角
			// front face
			new Vector2(0, 0),
			new Vector2(1, 0),
			new Vector2(0, 1),
			new Vector2(1, 1)
		};

		mesh.Clear(); // Clears all vertex data and all triangle indices.
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;

		mesh.MarkDynamic(); // 	Optimize mesh for frequent updates.
		mesh.RecalculateNormals(); // Recalculates the normals of the Mesh from the triangles and vertices.
	}

}