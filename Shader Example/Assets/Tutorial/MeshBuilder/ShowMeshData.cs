using UnityEngine;

public class ShowMeshData : MonoBehaviour
{
    public ShowOn showOn = ShowOn.vertices;

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        Vector2[] uvs = mesh.uv;

        switch (showOn)
        {
            case ShowOn.vertices:
                foreach (var var in vertices)
                {
                    print(var);
                }
                break;
            case ShowOn.triangles:
                foreach (var var in triangles)
                {
                    print(var);
                }
                break;
            case ShowOn.uvs:
                foreach (var var in uvs)
                {
                    print(var);
                }
                break;
        }
    }

}

public enum ShowOn
{
    vertices,
    triangles,
    uvs
}
