using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class HoverManager : MonoBehaviour
{
    [SerializeField]ClickData[] hoverSessionData;
    [SerializeField] AndroidSelector androidSelector;

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
    }

    void nextHoverSessionData(int index)
    {
        if (index > 0)
            hoverSessionData[index - 1].silenceCurrentButtons();

        hoverSessionData[index].wakeUpCurrentButtons();
    }

}

