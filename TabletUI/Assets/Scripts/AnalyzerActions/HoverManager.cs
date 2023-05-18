using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoverManager : MonoBehaviour
{
    [SerializeField]HoverSessionData[] hoverSessionData;
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
}

