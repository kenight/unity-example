using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoAndFadeOut : MonoBehaviour
{

    public string sceneName;
    public GameObject SceneFade;
    public float waitSecond = 0.5f;

    public void NextScene()
    {
        StartCoroutine(FadeAndWait());
    }

    IEnumerator FadeAndWait()
    {
        SceneFade.GetComponent<SceneFade>().FadeOut();
        yield return new WaitForSeconds(waitSecond);

        SceneManager.LoadScene(sceneName);
    }

}
