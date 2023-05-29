using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] ErrorPreset[] errorPresets;
    ErrorPreset activePreset;
    static int activePresetIndex=0;
    

    IEnumerator Start()
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

        yield return Start();

    }

    public static int GiveActivePresetIndex()
    {
        return activePresetIndex;
    }
}
