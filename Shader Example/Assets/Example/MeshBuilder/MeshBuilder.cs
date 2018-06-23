using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshBuilder : MonoBehaviour
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;

    // https://docs.unity3d.com/ScriptReference/Mesh.html
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
    }
}
