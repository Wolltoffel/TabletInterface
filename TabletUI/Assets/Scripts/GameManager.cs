using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    CheckForCable checkForCable = new CheckForCable();
    [SerializeField] bool activeCableToggle = false;
    [SerializeField] ScreenManager screenManager;
    [SerializeField] HoverManager hoverManager;
    AndroidSelector androidSelector;

    int cablePollingRate = 1;

    private IEnumerator Start()
    {
        androidSelector = AndroidSelector.instance;

        //Check if a cable is plugged in
        if (checkForCable.checkForChargingCable() /*&& activeCableToggle*/)
        {
            screenManager.switchScreen("MainScreen");
        }
            
        else
            screenManager.switchScreen("DisconnectScreen");
        
        yield return new WaitForSeconds(cablePollingRate);

        if (androidSelector.CheckScreenSwitchDue())
        {
            screenManager.switchScreen("UnplugScreen");
            hoverManager.nextHoverSessionData();

            //Reset all values
            androidSelector.resetValues();
            ClickToInteractWithGameObject.setActiveIndex(0);
        }

        //if last button pressed
        //AndroidSelector.instance.SwitchToNextAction

  
        yield return Start();
    }
}
