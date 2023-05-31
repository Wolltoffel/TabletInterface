using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorPreset : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] GameObject[] errorButtons;
    List<GameObject> visitedErrorButtons = new List<GameObject>();
    [SerializeField] GameObject backButton;
    [Space(10)]
    [SerializeField] GameObject analyzeButton;
    [SerializeField] Sprite activeSprite,passiveSprite;
    AnalyzeButton analyzeButtonScript;

    [Header ("Animations")]
    [SerializeField] AnimationPlayer[] loadanimationPlayers;
    [SerializeField] AnimationPlayerList[] clickAnimationPlayers;
    [SerializeField] AnimationPlayer[] backAnimationPlayers;
    [SerializeField] AnimationPlayer[] exitAnimationPlayers;

    [Header("Android")]
    [SerializeField]MeshRenderer androidModelRenderer;
    [SerializeField]Texture2D damageTexture;

    [Header ("Other")]
    [SerializeField]ProgressBar progressBar;
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

    public bool AnalyzeButtonPressed()
    {
        return analyzeButtonScript.GiveButtonState();
    }

    public bool GetAllErrorsVisited() 
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
        BackButton backButtonScript;

        if (backButton.GetComponent<BackButton>() == null)
        {
            backButtonScript = backButton.AddComponent<BackButton>();
        }
        else
        {
            backButtonScript = backButton.GetComponent<BackButton>();
        }

        backButtonScript.AssignPreset(this);
    }

    public void AssignScriptToAnalyzeButton()
    {

        if (backButton.GetComponent<AnalyzeButton>() == null)
        {
            analyzeButtonScript = analyzeButton.AddComponent<AnalyzeButton>();
        }
        else
        {
            analyzeButtonScript = analyzeButton.GetComponent<AnalyzeButton>();
        }

        analyzeButtonScript.AssignPreset(this);
        analyzeButtonScript.AssignSprites(activeSprite, passiveSprite);
        analyzeButtonScript.SetActive(false);
    }

    public void ResetAnalyzeButton()
    {
        analyzeButtonScript.ResetButton();
    }

    public void ActivateAnalyzeButton()
    {
        analyzeButtonScript.SetActive(true);
    }

    public void HideErrorButtons()
    {
        for (int i = 0; i < errorButtons.Length; i++)
        {
            errorButtons[i].SetActive(false);
        }
            
    }

    public void ShowButtons()
    {
        for (int i = 0; i < errorButtons.Length; i++)
        {
            errorButtons[i].SetActive(true);
        }
    }

    public IEnumerator LoadAnimations()
    {
        if (loadanimationPlayers != null)
        {
            for (int i = 0; i < loadanimationPlayers.Length; i++)
            {
                loadanimationPlayers[i].PlayLoadInAnimation();
            }
            yield return null;
        }
    }

    public IEnumerator ClickAnimation(int buttonIndex)
    {
        AnimationPlayer[] animationPlayers = clickAnimationPlayers[buttonIndex-1].animationPlayers;

        activeIndex = buttonIndex;

        for (int i = 0;i < animationPlayers.Length;i++) {
            yield return animationPlayers[i].startAnimationSequence(buttonIndex);
        }
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
        Debug.Log(index);
        GameObject lastVisit = errorButtons[index - 1];

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

    public void SetDamageTexture()
    {
        Material[] material = androidModelRenderer.sharedMaterials;
        for (int i=0;i<material.Length;i++)
        {
            if (material[i].name == "Damage")
            {
                material[i].SetTexture("_DamageTexture", damageTexture);
            }
        }
    }

    void UpdateProgressbar()
    {
        if (progressBar != null)
        progressBar.SetProgressValue(visitedErrorButtons.Count);
    }

    public void ResetProgressBar()
    {
        progressBar.ResetValues();
    }






}
