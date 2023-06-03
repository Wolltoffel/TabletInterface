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
        activePreset = errorPresets[0];
        yield return WaitForScreenToPlugIn();
        screenManager.switchScreen("MainScreen");
        gameloop = RunGameLoop();
        StartCoroutine(gameloop);
        StartCoroutine (checkCablePlug());
    }

    IEnumerator RunGameLoop()
    {
        activePreset = errorPresets[activePresetIndex];

        activePreset.AssignScriptsToErrorButtons();
        activePreset.AssignScriptToBackButton();
        activePreset.AssignScriptToAnalyzeButton();
        activePreset.SetDamageTexture();
  
        for (int i = 0; i < errorPresets.Length; i++)
        {
            if (i != activePresetIndex)
            {
                errorPresets[i].HideErrorButtons();
            }
        }
       activePreset.ShowButtons();

       yield return activePreset.LoadAnimations();   


        while (!activePreset.GetAllErrorsVisited())
        {
            yield return null;
        }

        activePreset.ActivateAnalyzeButton();

        while (!activePreset.AnalyzeButtonPressed())
        {
            yield return null;
        }

        yield return activePreset.ExitAnimation();

        activePresetIndex++;
        ErrorPreset.SetActiveIndex(0);
        activePreset.ResetProgressBar();
        activePreset.ResetAnalyzeButton();

        screenManager.switchScreen("TotalScreen");
        activePreset.CountUpAnimation();
        yield return WaitForScreenToPlugOut();
        screenManager.switchScreen("UnplugScreen");
        yield return WaitForScreenToPlugIn();

        yield return null;

        yield return RunGameLoop();

    }

    public static int GiveActivePresetIndex()
    {
        return activePresetIndex;
    }

    IEnumerator checkCablePlug()
    {
        yield return WaitForScreenToPlugOut(); 
        StopCoroutine(gameloop);
        screenManager.switchScreen("UnplugScreen");

        yield return WaitForScreenToPlugIn();
        
        screenManager.switchScreen("MainScreen");
        StartCoroutine(gameloop);
        yield return null;
        yield return checkCablePlug();
    }

    IEnumerator WaitForScreenToPlugIn() {
        while (!CheckForCable.checkForChargingCable() || !plugInCable)
        {
            yield return null;
        }

        Debug.Log("Cable has been plugged in");

        screenManager.switchScreen("ChargeAnimation");
        yield return activePreset.ChargeAnimation();
        
    }

    IEnumerator WaitForScreenToPlugOut()
    {
        while (CheckForCable.checkForChargingCable() && plugInCable)
        {
            yield return null;
        }
    }

    IEnumerator RunChargingAnimation()
    {
        
        yield return null;
    }

}
