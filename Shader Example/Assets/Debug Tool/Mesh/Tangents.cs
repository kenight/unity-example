using UnityEngine;

public class Tangents : MonoBehaviour
{
    Mesh mesh;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (mesh == null)
            return;

        for (int i = 0; i < mesh.tangents.Length; i++)
        {
            Gizmos.DrawRay(transform.position + mesh.vertices[i], mesh.tangents[i] * 0.1f);
        }
    }
}
