using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TypeWriterText : MonoBehaviour
{
    [SerializeField][Range (0,1)]float typeProgress;
    [SerializeField] private bool startTwOnGameStart = true;
    TextMeshProUGUI tmpPro;
    
    IEnumerator Start()
    {
        tmpPro = GetComponent<TextMeshProUGUI>();

        yield return new WaitForEndOfFrame();

        int totalVisibleCharacters = tmpPro.textInfo.characterCount;

        while (true)
        {
            int typeProgressInt = (int)Mathf.Round(typeProgress * 100);
            int visibleCount = typeProgressInt * totalVisibleCharacters/100;
            tmpPro.maxVisibleCharacters = visibleCount;
            Debug.Log("test");
            yield return null;
        }
    }

    private void OnEnable()
    {
        if (startTwOnGameStart) StartCoroutine(Start());
    }
}
