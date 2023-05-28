using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    CheckForCable checkForCable = new CheckForCable();
    [SerializeField] ScreenManager screenManager;
    HoverManager hoverManager;
    AndroidSelector androidSelector;
    bool cablePluggedIn;

    int cablePollingRate = 1;

    private IEnumerator Start()
    {
        androidSelector = AndroidSelector.instance;
        hoverManager = HoverManager.instance;

        StartCoroutine (checkForCablePlug());
        
        yield return null;

        if (androidSelector.CheckScreenSwitchDue())
        {
            SwitchToSecondAndroid();
            yield break;
        }


        yield return new WaitForSeconds(cablePollingRate);

         //if last button pressed
        //AndroidSelector.instance.SwitchToNextAction

  
        yield return Start();
    }

    IEnumerator checkForCablePlug()
    {
        while (cablePluggedIn == false)
        {
            if (checkForCable.checkForChargingCable())
            {
                screenManager.switchScreen("MainScreen");
            }

            else
                screenManager.switchScreen("DisconnectScreen");

            yield return new WaitForSeconds(cablePollingRate);
        }
    }

    void SwitchToSecondAndroid()
    {
        hoverManager.nextHoverSessionData();
    }
  
}
