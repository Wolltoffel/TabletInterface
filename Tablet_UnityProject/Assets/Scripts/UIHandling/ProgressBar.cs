using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar: MonoBehaviour
{
    [SerializeField]Image image;
    [SerializeField] TextMeshPro tmp;
    float animationDuration=0.1f;

    float progressValue;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ResetValues()
    {
        progressValue = 0;
        image.fillAmount = 0;
        tmp.text = string.Empty;
    }
    public void SetProgressValue(int progressValueRaw)
    {
        progressValue = progressValueRaw / 3.0f;
        StartCoroutine(AdjustValue());
    }
    IEnumerator AdjustValue()
    {
        //Save Progress Value
        float sliderValue = image.fillAmount;
        float current = sliderValue;
        if (progressValue > sliderValue)
        {
            float startTime = Time.time;
            while (current != progressValue)
            {
                //Animate Slider over time
                float t = (Time.time - startTime) / animationDuration;
                current = Mathf.Lerp(sliderValue, progressValue, t);
                image.fillAmount = current;
                tmp.text = $"{current.ToString()}%";
                yield return null;
            }
        }
    }


    /*IEnumerator AdjustValue()
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
}*/

}
