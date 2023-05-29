using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ErrorButtons : MonoBehaviour, IPointerDownHandler
{
    ErrorPreset preset;
    int buttonIndex;

    public void AssignData(ErrorPreset preset, int buttonIndex)
    {
        this.preset = preset;
        this.buttonIndex = buttonIndex;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartCoroutine(preset.ClickAnimation(buttonIndex));
    }

}
