using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PlaneBuilder : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0,1,0), // 0
            new Vector3(1,1,0), // 1
            new Vector3(0,0,0), // 2
            new Vector3(1,0,0), // 3
        };

        // 三个顶点形成一个 triangle 
        // 顺时针的三个点决定哪个面将被渲染出来
        int[] triangles = new int[]
        {
            // 显示正面
            1,3,2,
            2,0,1
            // 显示背面
            //0,2,3,
            //3,1,0
        };

        // 按顶点 index 定义对应的贴图坐标
        Vector2[] uvs = new Vector2[] {
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(0,0),
            new Vector2(1,0),
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
    }
}
