using UnityEngine;

public class Animated : MonoBehaviour
{
    public float speed = 1;
    public bool primary = true;

    Material mat;
    float threshold;

    void Awake()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void Start()
    {
        threshold = primary ? 1 : 0;
    }

    void Update()
    {
        if (primary)
        {
            threshold -= speed * Time.deltaTime;
        }
        else
        {
            threshold += speed * Time.deltaTime;
        }

        threshold = Mathf.Clamp01(threshold);
        mat.SetFloat("_Threshold", threshold);
    }
}
