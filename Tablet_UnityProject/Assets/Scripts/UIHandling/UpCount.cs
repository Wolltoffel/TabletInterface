using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Globalization;

public class UpCount : MonoBehaviour
{
    [SerializeField] public int number;
    [SerializeField][Range(0, 1)] float countProgress;
    TextMeshProUGUI tmpPro;

    CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

    IEnumerator CountUp()
    {
        tmpPro = GetComponent<TextMeshProUGUI>();

        yield return new WaitForEndOfFrame();

        while (true)
        {
            tmpPro.text = number.ToString("C",culture);
            yield return null;
        }
    }


    private void OnEnable()
    {
        StartCoroutine(CountUp());
    }

    private void OnDisable()
    {
        StopCoroutine(CountUp());
    }
}

