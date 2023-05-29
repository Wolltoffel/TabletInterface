using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class PresetSelector: MonoBehaviour
{
    [SerializeField]ClickData[] clickData;
    int activeAndroid=0;
    public static PresetSelector instance;

    private void Start()
    {
        if (instance != this)
        {
            Destroy(instance);
            instance = this;
        }

        setUpButtons();
        startAnimations(activeAndroid);
    }

    void setUpButtons()
    {
        clickData[activeAndroid].AddScriptsToClickables();
        for (int i = 0; i < clickData.Length; i++)
        {
            if (i != activeAndroid)
                clickData[i].silenceCurrentButtons();
        }
        clickData[activeAndroid].wakeUpCurrentButtons();
        InteractionCounter.instance.InsertClickables(clickData[activeAndroid].giveClickables());
    }

    public  int GetActiveAndroidIndex()
    {
        return activeAndroid;
    }

    public void nextPreset()
    {
        activeAndroid++;
        setUpButtons();
        startAnimations(activeAndroid);
    }

    public void startAnimations(int clickDataIndex)
    {
        GameObject[] clickables = clickData[clickDataIndex].giveClickables();

        for (int i = 0; i < clickables.Length; i++)
        {
            StartCoroutine(clickables[i].GetComponent<ClickToInteractWithGameObject>().startAnimations());
        }

        
    }

}

