using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoverSessionData : MonoBehaviour
{
    [SerializeField]GameObject[] clickables; //Saves Clickable Objects
    [SerializeField]UnityEvent<HoverInformation>[] unityEvents; //Saves Unity Events
    public bool onActive = true;

    public GameObject[] giveClickables()
    {
        return clickables;
    }

    public void ConnectEvents() //Connects the events to the gameobjects
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script  = clickables[i].AddComponent<ClickToInteractWithGameObject>();
            script.InsertSetUpData(new HoverInformation(i), unityEvents[i]);
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
