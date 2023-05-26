using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HoverManager : MonoBehaviour
{
    [SerializeField]ClickData[] hoverSessionData;
    [SerializeField] AndroidSelector androidSelector;
    int activeHoverIndex;

    private void Start()
    {
        for (int i = 0; i < hoverSessionData.Length; i++)
        {
            hoverSessionData[i].ConnectEvents();
            if (i!=0)
                hoverSessionData[i].silenceCurrentButtons();
            if (hoverSessionData[i].onActive)
                androidSelector.AddActiveHoverSessionData(hoverSessionData[i].giveClickables());
        }
        activeHoverIndex = 0;
    }

    public void nextHoverSessionData()
    {
        if (activeHoverIndex > 0)
            hoverSessionData[activeHoverIndex - 1].silenceCurrentButtons();

        hoverSessionData[activeHoverIndex].wakeUpCurrentButtons();
    }

}

