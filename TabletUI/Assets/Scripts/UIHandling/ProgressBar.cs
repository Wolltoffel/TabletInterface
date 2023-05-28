using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Slider progressSlider;
    float animationDuration=0.1f;

    private void Awake()
    {
        progressSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        StartCoroutine(checkValue());
    }

    IEnumerator checkValue()
    {
        while (true)
        {
            //Save Progress Value
            float progressValue = AndroidSelector.instance.GiveInteractionNumber()/3.0f;
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
            yield return null;
        }
    }
}
