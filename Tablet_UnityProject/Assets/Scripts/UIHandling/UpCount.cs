using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Globalization;

public class UpCount : MonoBehaviour
{
    int counter = 0;
    [SerializeField]int stepSize;
    [SerializeField] float animationDuration;
    [SerializeField]TextMeshProUGUI tmpPro;

    CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

    IEnumerator CountUp(int maxNumber)
    {
        tmpPro = GetComponent<TextMeshProUGUI>();

        float counterFloat = counter;

        while (counterFloat<maxNumber)
        {   
            counter +=stepSize;
            counterFloat = counter * stepSize * Time.deltaTime;
            tmpPro.text = counterFloat.ToString("C", culture);
            yield return new WaitForSeconds(animationDuration);
            yield return null;
        }
    }

    public void StartCountUpAnimaton(int maxNumber)
    {
        StartCoroutine(CountUp(maxNumber));
    }
}

