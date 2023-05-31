using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ErrorButtons : MonoBehaviour, IPointerDownHandler
{
    ErrorPreset preset;
    int buttonIndex;
    bool hasBeenSelectedOnce=false;

    public void AssignData(ErrorPreset preset, int buttonIndex)
    {
        this.preset = preset;
        this.buttonIndex = buttonIndex;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        hasBeenSelectedOnce = true;
        StartCoroutine(preset.ClickAnimation(buttonIndex));
    }

    public bool GetHasBeenClickedOnce()
    {
        return hasBeenSelectedOnce;
    }

    public void SetHasBeenClickedOnce(bool hasBeenSelectedOnce) {
        this.hasBeenSelectedOnce = hasBeenSelectedOnce;
    }

}
