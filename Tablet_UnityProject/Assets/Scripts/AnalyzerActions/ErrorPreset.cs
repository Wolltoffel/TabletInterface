using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorPreset : MonoBehaviour
{


    [Header("Buttons")]
    [SerializeField] GameObject[] errorButtons;
    [SerializeField] GameObject backButton;

    //ExposedValues
    [Header ("Animations")]
    [SerializeField] AnimationPlayer[] loadanimationPlayers;
    [SerializeField] AnimationPlayerList[] clickAnimationPlayers;
    [SerializeField] AnimationPlayer[] backAnimationPlayers;
    [SerializeField] AnimationPlayer[] exitAnimationPlayers;

    [Header ("Other")]
    [SerializeField]ProgressBar progressBar;



    List <GameObject> visitedErrorButtons = new List<GameObject>();

    static int activeIndex;


    #region Getter And Setter
    public static int GetActiveIndex()
    {
        return activeIndex;
    }

    public static void SetActiveIndex (int newIndex)
    {
        activeIndex = newIndex;
    }

    public bool GetNextPresetDue()
    {
        if (visitedErrorButtons.Count >= errorButtons.Length)
            return true;
        return false;
    }
    #endregion

    public void AssignScriptsToErrorButtons()
    {
        for (int i = 0; i < errorButtons.Length; i++)
        {
            var errorButtonScript = errorButtons[i].AddComponent<ErrorButtons>();
            errorButtonScript.AssignData(this,i+1);
        }
    }

    public void AssignScriptToBackButton()
    {
        var backButtonScript = backButton.AddComponent<BackButton>();
        backButtonScript.AssignPreset(this);
    }

    public IEnumerator LoadAnimations()
    {
        if (loadanimationPlayers != null)
        {
            for (int i = 0; i < loadanimationPlayers.Length; i++)
            {
                loadanimationPlayers[i].PlayAnimation(0);
            }
            yield return null;
        }
    }

    public IEnumerator ClickAnimation(int buttonIndex)
    {
        AnimationPlayer[] animationPlayers = clickAnimationPlayers[buttonIndex-1].animationPlayers;

        for (int i = 0;i < animationPlayers.Length;i++) {
            yield return animationPlayers[i].startAnimationSequence(buttonIndex);
        }
        
        activeIndex = buttonIndex;
    }

    public void GoBack()
    {
       StartCoroutine(BackAnimation());
       LogButtonVisit(activeIndex);
       UpdateProgressbar();
       activeIndex = 0;
    }

    IEnumerator BackAnimation()
    {
        for (int i = 0; i < backAnimationPlayers.Length; i++)
        {
            yield return backAnimationPlayers[i].startAnimationSequence(activeIndex);
        }
    }

    void LogButtonVisit(int index)
    {
        GameObject lastVisit = errorButtons[index-1];

        if (!visitedErrorButtons.Contains(lastVisit))
            visitedErrorButtons.Add(lastVisit);
    }

    public IEnumerator ExitAnimation()
    {
        for (int i = 0; i < exitAnimationPlayers.Length; i++)
        {
            yield return exitAnimationPlayers[i].startAnimationSequence(activeIndex);
        }
    }

    void UpdateProgressbar()
    {
        if (progressBar != null)
        progressBar.SetProgressValue(visitedErrorButtons.Count);
    }

    public void ResetProgressBar()
    {
        progressBar.SetProgressValue(0);
    }





}
