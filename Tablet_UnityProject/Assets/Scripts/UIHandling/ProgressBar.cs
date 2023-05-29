using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider progressSlider;
    float animationDuration=0.1f;

    float progressValue;

    private void Awake()
    {
        progressSlider = GetComponent<Slider>();
    }

    public void ResetValues()
    {
        progressValue = 0;
        progressSlider.value = 0;
    }
    public void SetProgressValue(int progressValueRaw)
    {
        progressValue = progressValueRaw / 3.0f;
        StartCoroutine(AdjustValue());
    }
    IEnumerator AdjustValue()
    {
        //Save Progress Value
        float sliderValue = progressSlider.value;
        float current = sliderValue;
        if(progressValue > sliderValue)
        {
            float startTime = Time.time;
            while (current!=progressValue)
            {
                //Animate Slider over time
                float t = (Time.time - startTime) / animationDuration;
                current = Mathf.Lerp(sliderValue, progressValue, t);
                progressSlider.value = current;
                yield return null;
            }
        }
    }

}
