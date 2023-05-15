using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoverInformation
{
    public int index;
    public UnityEvent<HoverInformation> unityEvent;

    public HoverInformation(int index, UnityEvent<HoverInformation> unityEvent)
    {
        this.index = index;
        this.unityEvent = unityEvent;
    }
}
