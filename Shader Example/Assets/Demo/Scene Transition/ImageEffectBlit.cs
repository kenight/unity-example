using UnityEngine;

[ExecuteInEditMode]
public class ImageEffectBlit : MonoBehaviour
{
    public Material material;

    void OnRenderImage(RenderTexture s, RenderTexture d)
    {
        Graphics.Blit(s, d, material);
    }
}
