using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Globalization;

public class UpCount : MonoBehaviour
{
    int counter = 0;
    [SerializeField] float animationDuration;
    [SerializeField]TextMeshProUGUI tmpPro;

    CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

    IEnumerator CountUp(int maxNumber)
    {
        tmpPro = GetComponent<TextMeshProUGUI>();

        yield return new WaitForEndOfFrame();

        while (true)
        {   
            tmpPro.text = counter.ToString("C",culture);
            counter++;
            yield return new WaitForSeconds(animationDuration);
        }
    }

    public void StartCountUpAnimaton(int maxNumber)
    {
        StartCoroutine(CountUp(maxNumber));
    }

  


}

