using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HoverManager: MonoBehaviour
{
    [SerializeField]ClickData[] hoverSessionData;
    [SerializeField] AndroidSelector androidSelector;
    int activeAndroid=0;
    public static HoverManager instance;
    List<Collider> colliders  = new List<Collider>();

    private void Start()
    {
        if (instance != this)
        {
            Destroy(instance);
            instance = this;
        }

        for (int i = 0; i < hoverSessionData.Length; i++)
        {
            colliders.AddRange(hoverSessionData[i].GiveColliders());
        }

            insertData();
    }

    void insertData()
    {
        for (int i = 0; i < hoverSessionData.Length; i++)
        {
            hoverSessionData[i].ConnectEvents();
            if (i != activeAndroid)
                hoverSessionData[i].silenceCurrentButtons();
            if (hoverSessionData[i].onActive)
                androidSelector.AddActiveHoverSessionData(hoverSessionData[i].giveClickables());
        }
        hoverSessionData[activeAndroid].wakeUpCurrentButtons();
    }

    public  int GetActiveAndroidIndex()
    {
        return activeAndroid;
    }

    public void nextHoverSessionData()
    {
        if (activeAndroid > 0)
            hoverSessionData[activeAndroid - 1].silenceCurrentButtons();

        activeAndroid++;
        hoverSessionData[activeAndroid].wakeUpCurrentButtons();
    }

    public void deactivateAllColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }
    }

    public void activateAllColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = true;
        }
    }

}

