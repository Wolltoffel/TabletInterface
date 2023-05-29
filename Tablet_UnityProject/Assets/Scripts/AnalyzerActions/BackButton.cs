using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BackButton : MonoBehaviour,IPointerDownHandler
{

    ErrorPreset preset;

    public void AssignPreset(ErrorPreset preset)
    {
        this.preset = preset;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        preset.GoBack();
    }

}
