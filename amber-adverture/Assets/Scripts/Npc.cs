using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject buttonZ;
    private bool canTalk = false;

    void Update()
    {
        if (!canTalk)
            return;

        if (Input.GetKeyDown(KeyCode.Z) && GameplayManager.instance.pause == false)
            GameplayManager.instance.ShowDialog();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;
        canTalk = true;
        buttonZ.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
            return;
        canTalk = false;
        buttonZ.SetActive(false);
    }

}
