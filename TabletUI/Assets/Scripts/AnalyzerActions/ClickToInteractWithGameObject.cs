using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
     HoverInformation hoverInfo;
     UnityEvent<HoverInformation> hoverEvent;

    public void OnPointerDown (PointerEventData eventData)
    {
        hoverEvent?.Invoke(hoverInfo);
    }

    public void InsertSetUpData(HoverInformation hoverInfo, UnityEvent<HoverInformation> hoverEvent)
    {
        this.hoverInfo = hoverInfo;
        this.hoverEvent=hoverEvent;
    }
}
