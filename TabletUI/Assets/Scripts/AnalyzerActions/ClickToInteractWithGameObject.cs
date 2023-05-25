using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;


public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public int index;
    UnityEvent<int> eventToExecute;
    public static int activeIndex = 0;
    IAnimationManager[] animationManagers;

    public void OnPointerDown(PointerEventData eventData)
    {
        activeIndex = index;
    }

    public void InsertSetUpData(int index, UnityEvent<int> hoverEvent, IAnimationManager[] animationManagers)
    {
        this.index = index;
        this.eventToExecute = hoverEvent;
        this.animationManagers = animationManagers;
    }

    
 }




