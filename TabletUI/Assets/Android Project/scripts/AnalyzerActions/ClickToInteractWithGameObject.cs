using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickToInteractWithGameObject : MonoBehaviour
{
    public HoverInformation hoverInfo;

    private void OnMouseDown()
    {
        hoverInfo.unityEvent?.Invoke(hoverInfo);
        Debug.Log(hoverInfo.index);
    }
}
