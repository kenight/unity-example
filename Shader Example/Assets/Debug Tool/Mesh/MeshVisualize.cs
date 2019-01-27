using UnityEngine;

public class MeshVisualize : MonoBehaviour
{
    public bool showVertices = true;
    public Color vertexColor = Color.cyan;
    public float radius = 0.01f;

    public bool showNormals = true;
    public Color normalColor = Color.yellow;
    public float normalLength = 0.03f;

    public bool showTangents = true;
    public Color tangentColor = Color.red;
    public float tangentLength = 0.03f;

    Mesh mesh;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnDrawGizmosSelected()
    {
        if (mesh == null)
            return;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            if (showVertices)
            {
                Gizmos.color = vertexColor;
                Gizmos.DrawSphere(transform.position + mesh.vertices[i], radius);
            }

            if (showNormals)
            {
                Gizmos.color = normalColor;
                Gizmos.DrawRay(transform.position + mesh.vertices[i], mesh.normals[i] * normalLength);
            }

            if (showTangents)
            {
                Gizmos.color = tangentColor;
                Gizmos.DrawRay(transform.position + mesh.vertices[i], mesh.tangents[i] * tangentLength);
            }
        }
    }
}
