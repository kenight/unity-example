using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{

    public GameObject menu;
    public AudioClip pressClip;

    void Update()
    {
        if (Input.anyKey)
        {
            this.gameObject.SetActive(false);
            menu.SetActive(true);
            AudioManager.instance.PlayEffect(pressClip);
        }

    }

}
