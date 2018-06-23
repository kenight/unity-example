using UnityEngine;

public class Bitangents : MonoBehaviour
{

    Mesh mesh;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (mesh == null)
            return;

        for (int i = 0; i < mesh.tangents.Length; i++)
        {
            Vector3 bitangent = Vector3.Cross(mesh.normals[i], mesh.tangents[i]) * mesh.tangents[i].w; // w 用于确定副切线的方向
            Gizmos.DrawRay(transform.position + mesh.vertices[i], bitangent * 0.1f);
        }
    }
}
