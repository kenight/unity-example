using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{

    public GameObject obj;
    public float delay = 0.0f;

    void Show()
    {
        Invoke("SetActive", delay);
    }

    void SetActive()
    {
        obj.SetActive(true);
    }

}
