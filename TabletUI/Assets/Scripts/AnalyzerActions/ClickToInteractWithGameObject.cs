using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
    public HoverInformation hoverInfo;

    public void OnPointerDown (PointerEventData eventData)
    {
        hoverInfo.unityEvent?.Invoke(hoverInfo);
        Debug.Log(hoverInfo.index);
    }
}
