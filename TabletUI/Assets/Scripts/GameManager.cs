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

    int cablePollingRate = 1;

    private IEnumerator Start()
    {
        //Check if a cable is plugged in
        if (checkForCable.checkForChargingCable() /*&& activeCableToggle*/)
        {
            screenManager.switchScreen("MainScreen");
        }
            
        else
            screenManager.switchScreen("DisconnectScreen");
        
        yield return new WaitForSeconds(cablePollingRate);
  
        yield return Start();
    }
}