using System;
using System.Collections;
using System.Collections.Generic;
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

    public GameObject[] giveClickables()
    {
        return clickables;
    }

    public void ConnectEvents() //Connects the events to the gameobjects
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script  = clickables[i].AddComponent<ClickToInteractWithGameObject>();
            script.InsertSetUpData(i,animationSequenceLists[i]);
        }
        
        backButton.insertData(animationSequenceLists);

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
