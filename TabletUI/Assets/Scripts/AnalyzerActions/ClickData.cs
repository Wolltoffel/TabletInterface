using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ClickData : MonoBehaviour
{
    [SerializeField]GameObject[] clickables; //Saves Clickable Objects / each button
    public bool onActive = true;

    [SerializeField]BackButton backButton;

    public AnimationSequenceList[] animationSequenceLists;

    public AnimationSequenceList exitZoomAnimations;

    public GameObject[] giveClickables()
    {
        return clickables;
    }

    public void ConnectEvents() //Connects the events to the gameobjects
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script  = clickables[i].AddComponent<ClickToInteractWithGameObject>();
            script.InsertSetUpData(i+1,animationSequenceLists[i],backButton,exitZoomAnimations);
        }
    }

    public void silenceCurrentButtons() {
       
        for (int i = 0; i < clickables.Length; i++)
        {
            var script = clickables[i].GetComponent<ClickToInteractWithGameObject>();
            script.enabled = false;
            onActive = false;
            clickables[i].SetActive(false);
        }
    }

    public void wakeUpCurrentButtons()
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script = clickables[i].GetComponent<ClickToInteractWithGameObject>();
            script.enabled = true;
            onActive = true;
            clickables[i].SetActive(true);
        }
    }

    public List<Collider> GiveColliders()
    {
        List<Collider> list = new List<Collider>();
        for (int i = 0; i < clickables.Length; i++)
        {
            list.Add(clickables[i].GetComponentInChildren<Collider>());
        }
        return list;
    }

}
