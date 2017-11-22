using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{

    public float delay = 0;

    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animation>().Play();
    }
}
