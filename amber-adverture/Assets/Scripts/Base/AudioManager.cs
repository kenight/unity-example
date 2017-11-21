using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 游戏声音管理器，应具备的功能包括：开关声音、控制音量、播放音效
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource bgm;
    public AudioSource effect;

    void Awake()
    {
        instance = this;
    }

    public void PlayEffect(AudioClip clip)
    {
        effect.PlayOneShot(clip);
    }

}
