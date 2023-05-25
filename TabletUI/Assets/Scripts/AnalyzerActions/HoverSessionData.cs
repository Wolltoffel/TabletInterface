using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[Serializable]
public class AnimationManagerHolder
{
    public List<GameObject> list;
}

public class HoverSessionData : MonoBehaviour
{
    [SerializeField]GameObject[] clickables; //Saves Clickable Objects / each button
    [SerializeField]UnityEvent<int>[] clickEvents; //Saves Unity Events for each button
    public bool onActive = true;
    [SerializeField]List<AnimationManagerHolder> animationManagers;


    public GameObject[] giveClickables()
    {
        return clickables;
    }

    public void ConnectEvents() //Connects the events to the gameobjects
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script  = clickables[i].AddComponent<ClickToInteractWithGameObject>();
            //script.InsertSetUpData(i, clickEvents[i], animationManager);
        }
    }

    public void silenceCurrentButtons() {
       
        for (int i = 0; i < clickables.Length; i++)
        {
            var script = clickables[i].GetComponent<ClickToInteractWithGameObject>();
            script.enabled = false;
            onActive = false;
        }
    }
}
