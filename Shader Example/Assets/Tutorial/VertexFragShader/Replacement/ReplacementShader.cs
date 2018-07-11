using UnityEngine;

[ExecuteInEditMode]
public class ReplacementShader : MonoBehaviour
{
    public Shader replacementShader;
    public Color replaceColor;

    // This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only).
    void OnValidate()
    {
        // set the global color property for all shaders
        Shader.SetGlobalColor("_ReplaceColor", replaceColor);
    }

    void OnEnable()
    {
        if (replacementShader != null)
        {
            GetComponent<Camera>().SetReplacementShader(replacementShader, ""); // tag 对应 shader RenderType
        }
    }

    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }
}
