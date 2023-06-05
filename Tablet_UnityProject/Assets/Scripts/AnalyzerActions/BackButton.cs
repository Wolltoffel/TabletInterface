using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BackButton : MonoBehaviour,IPointerDownHandler
{

    ErrorPreset preset;
    bool active = true;

    public void AssignPreset(ErrorPreset preset)
    {
        this.preset = preset;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (active)
        {
            preset.GoBack();
        }
        active = false;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

}
