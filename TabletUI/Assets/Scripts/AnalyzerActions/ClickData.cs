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

    [SerializeField]BackButton backButton;

    public AnimationPlayerList[] animationSequenceLists;

    public AnimationPlayerList exitZoomAnimations;

    public GameObject[] giveClickables()
    {
        return clickables;
    }

    public void AddScriptsToClickables() //Connects the events to the gameobjects
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
            clickables[i].SetActive(false);
        }
    }

    public void wakeUpCurrentButtons()
    {
        for (int i = 0; i < clickables.Length; i++)
        {
            var script = clickables[i].GetComponent<ClickToInteractWithGameObject>();
            clickables[i].SetActive(true);
        }
    }

}
