using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumnSlider;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Slider On Vaule Changed Event
    public void OnVolumnSliderChange()
    {
        audioSource.volume = volumnSlider.value;
    }
}
