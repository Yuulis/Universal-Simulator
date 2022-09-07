using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimescaleSlider : MonoBehaviour
{
    Settings settings;
    Slider slider;


    void Start()
    {
        settings = GameObject.Find("Settings").GetComponent<Settings>();
        slider = GetComponent<Slider>();

        slider.minValue = settings.timescale_min;
        slider.maxValue = settings.timescale_max;
        slider.value = 1.0f;
    }


    public void UpdateTimescale()
    {
        Time.timeScale = slider.value;
    }
}
