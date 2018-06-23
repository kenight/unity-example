using UnityEngine;

public class Vertices : MonoBehaviour
{
    Mesh mesh;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        if (mesh == null)
            return;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.position + mesh.vertices[i], 0.01f);
        }
    }
}
