using System.Collections;
using UnityEngine;
using TMPro;

public class TypeWriterText : MonoBehaviour
{
    [SerializeField][Range (0,1)]float typeProgress;
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
            yield return null;
        }
    }

    private void OnEnable()
    {
      StartCoroutine(Start());
    }
}
