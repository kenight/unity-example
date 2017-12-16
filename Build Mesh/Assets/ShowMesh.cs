using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMesh : MonoBehaviour {

	void Start() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		// 顶点
		Vector3[] verts = mesh.vertices;
		Debug.Log("vertices count is : " + verts.Length);
		foreach (var vert in verts) {
			Debug.Log(vert);
		}
		// 三角形数组
		int[] triangles = mesh.triangles;
		Debug.Log("triangles count is : " + triangles.Length);
		foreach (var triangle in triangles) {
			Debug.Log(triangle);
		}
		// UV
		Vector2[] uv = mesh.uv;
		Debug.Log("UV count is : " + uv.Length);
		foreach (var u in uv) {
			Debug.Log(u);
		}
	}

}