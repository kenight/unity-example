﻿using UnityEngine;

[ExecuteInEditMode]
public class PostProcessingStack : MonoBehaviour
{
    public Material mat;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
}
