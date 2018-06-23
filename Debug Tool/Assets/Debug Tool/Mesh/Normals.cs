using UnityEngine;

public class Normals : MonoBehaviour
{
    Mesh mesh;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (mesh == null)
            return;

        for (int i = 0; i < mesh.normals.Length; i++)
        {
            Gizmos.DrawRay(transform.position + mesh.vertices[i], mesh.normals[i] * 0.1f);
        }
    }
}
