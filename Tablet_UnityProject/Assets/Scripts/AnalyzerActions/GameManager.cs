using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ErrorPreset[] errorPresets;
    [SerializeField] ScreenManager screenManager;

    [Header("Cable Unplug")]
    [SerializeField]bool plugInCable;
    
    ErrorPreset activePreset;
    static int activePresetIndex=0;
    IEnumerator gameloop;

    private IEnumerator Start()
    {
        while (!CheckForCable.checkForChargingCable() || !plugInCable)
        {
            Debug.Log("Checking for cable..,");
            yield return null;
        }
        screenManager.switchScreen("MainScreen");
        gameloop = RunGameLoop();
        StartCoroutine(gameloop);
        StartCoroutine (checkCablePlug());
    }

    IEnumerator RunGameLoop()
    {
        activePreset = errorPresets[activePresetIndex];

        activePreset.AssignScriptsToErrorButtons();
        yield return activePreset.LoadAnimations();
        activePreset.AssignScriptToBackButton();

        while (!activePreset.GetNextPresetDue())
        {
            yield return null;
        }

        activePreset.ResetProgressBar();
        yield return activePreset.ExitAnimation();

        activePresetIndex++;
        ErrorPreset.SetActiveIndex(0);
        yield return null;

        yield return RunGameLoop();

    }

    public static int GiveActivePresetIndex()
    {
        return activePresetIndex;
    }

    IEnumerator checkCablePlug()
    {
        while (CheckForCable.checkForChargingCable() && plugInCable)
        {
            Debug.Log("CablePluggedIn");
            yield return null;
        }
        StopCoroutine(gameloop);
        screenManager.switchScreen("DisconnectScreen");
       
        while (!CheckForCable.checkForChargingCable() || !plugInCable)
        {
            Debug.Log("CablePluggedOut");
            yield return null;
        }
        screenManager.switchScreen("MainScreen");
        StartCoroutine(gameloop);
        yield return null;
        yield return checkCablePlug();
    }

}
