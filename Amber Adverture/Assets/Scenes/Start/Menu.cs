using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public Transform[] menus;
    public Transform pointer;
    public AudioClip moveClip;
    public AudioClip confirmClip;
    private int menuIndex;

    // Use this for initialization
    void Start()
    {
        // 初始位置
        pointer.position = new Vector2(pointer.position.x, menus[0].position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            menuIndex++;
            MovePointer();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            menuIndex--;
            MovePointer();
        }
    }

    void MovePointer()
    {
        menuIndex = Mathf.Clamp(menuIndex, 0, 2);
        pointer.position = new Vector2(pointer.position.x, menus[menuIndex].position.y);
        AudioManager.instance.PlayEffect(moveClip);
    }
}
