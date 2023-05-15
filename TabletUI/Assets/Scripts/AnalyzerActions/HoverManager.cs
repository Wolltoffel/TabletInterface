using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoverManager : MonoBehaviour
{

    [SerializeField]GameObject[] hoverGameObject;
    [SerializeField] UnityEvent<HoverInformation>[] unityEvents;
    [SerializeField] HoverInformation hoverInformation;

    private void Awake()
    {
        for (int i = 0; i < hoverGameObject.Length; i++)
        {
           var hoverScript = hoverGameObject[i].AddComponent<ClickToInteractWithGameObject>();
           hoverScript.hoverInfo = new HoverInformation(i, unityEvents[i]);
        }
    }
}

