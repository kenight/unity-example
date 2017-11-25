using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Slider slider;

    public void OnSliderChange()
    {
        Debug.Log(slider.value);
    }
}
