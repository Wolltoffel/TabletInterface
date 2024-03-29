using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ErrorPreset : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] GameObject[] errorButtons;
    List<GameObject> visitedErrorButtons = new List<GameObject>(); //reset
    ErrorButtons[] errorButtonScripts;
    [SerializeField] GameObject backButton;
    BackButton backButtonScript;
    [Space(20)]
    [SerializeField] GameObject analyzeButton;
    [SerializeField] Sprite activeSprite,passiveSprite;
    AnalyzeButton analyzeButtonScript;

    [Header ("Animations")]
    [SerializeField] AnimationPlayer[] loadanimationPlayers;
    [Space(20)]
    [SerializeField] AnimationPlayerList[] clickAnimationPlayers;
    [Space(20)]
    [SerializeField] AnimationPlayer[] backAnimationPlayers;
    [Space(20)]
    [SerializeField] AnimationPlayer[] exitAnimationPlayers;
    [Space(20)]
    [SerializeField] AnimationPlayer[] countUpAnimations;
    [SerializeField] int estimatedCost;
    [Space(20)]
    [SerializeField] AnimationPlayer[] chargingAnimations;

    [Header("Android")]
    [SerializeField]MeshRenderer androidModelRenderer;
    [SerializeField]Texture2D damageTexture;

    [Header("Other")]
    [SerializeField] AudioClip[] voiceLines;
    AudioSource voiceSource;
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
        errorButtonScripts = new ErrorButtons[errorButtons.Length];

        for (int i = 0; i < errorButtons.Length; i++)
        {
            errorButtonScripts[i] = errorButtons[i].AddComponent<ErrorButtons>();
            errorButtonScripts[i].AssignData(this,i+1);
           
            ButtonAnimations buttonAnimationComponent = errorButtonScripts[i].GetButtonAnimationComponent();
            if (buttonAnimationComponent!=null)
                buttonAnimationComponent.SetIndex(i+1);
        }
    }

    public void AssignScriptToBackButton()
    {

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

    public void TryActivateAnalyzeButton()
    {
        if (visitedErrorButtons.Count>=3)
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
                loadanimationPlayers[i].PlayAnimation(0,false);
            }
            yield return null;
        }
    }

    public IEnumerator ClickAnimation(int buttonIndex)
    {
        AnimationPlayer[] animationPlayers = clickAnimationPlayers[buttonIndex-1].animationPlayers;

        activeIndex = buttonIndex;
        LogButtonVisit(activeIndex);
        UpdateProgressbar();
        backButton.SetActive(true);

        for (int i = 0;i < animationPlayers.Length;i++) {

            if (animationPlayers[i] is ButtonAnimations) {
            }

            if (i== animationPlayers.Length-1)
            {
                //AudioSource.PlayClipAtPoint(voiceLines[activeIndex - 1], Camera.main.transform.position);
                PlaySoundOneShot(voiceLines[activeIndex - 1]);
            }

            yield return animationPlayers[i].startAnimationSequence(buttonIndex, false);
        }

    }

    public void GoBack()
    {
       StartCoroutine(BackAnimation());
    }
    
    IEnumerator BackAnimation()
    {
        TryActivateAnalyzeButton();
        StopVoice();

        //Check if the active button has been pressed for the first time
        errorButtonScripts[activeIndex - 1].SetHasBeenClicked(true); //Set the newly clicked button animation to true

        for (int i = 0; i < backAnimationPlayers.Length; i++)
        {
           bool hasBeenClicked=false;
           int index =  backAnimationPlayers[i].GetIndex(); // Get the index of the AnimationPlayer
           if (index > 0)//If index is larger than zero it means the component has an error button component
                hasBeenClicked = errorButtonScripts[index - 1].GetHasBeenClicked();//if that's the case it has to be checked whether it was already clicked on
            yield return backAnimationPlayers[i].startAnimationSequence(activeIndex, hasBeenClicked); 
        }

        //Reset activeIndex
        activeIndex = 0;
        backButtonScript.SetActive(true);
    }
    void LogButtonVisit(int index)
    {
        GameObject lastVisit = errorButtons[index - 1];

        if (!visitedErrorButtons.Contains(lastVisit))
            visitedErrorButtons.Add(lastVisit);
    }

    public IEnumerator ExitAnimation()
    {
        for (int i = 0; i < exitAnimationPlayers.Length; i++)
        {
            yield return exitAnimationPlayers[i].startAnimationSequence(activeIndex,false);
        }
    }

    public void CountUpAnimation()
    {
        for (int i = 0; i < countUpAnimations.Length; i++)
        {
            countUpAnimations[i].PlayAnimation(estimatedCost);
        }
    }

    public IEnumerator ChargeAnimation()
    {
        for (int i = 0; i < countUpAnimations.Length; i++)
        {
           /* if (chargingAnimations[i] is ChargingAnimations)
            {
                ChargingAnimations chA = chargingAnimations[i] as ChargingAnimations;
                yield return chA.PlayVideo();
            }
            else*/
               yield return chargingAnimations[i].startAnimationSequence(0, false);
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

    public void ResetAnimations()
    {
        analyzeButtonScript.SetActive(false);

        List<AnimationPlayer[]> allAnimations = new List<AnimationPlayer[]>();
        allAnimations.Add(loadanimationPlayers);
        for (int i = 0;i< clickAnimationPlayers.Length;i++)
        {
            allAnimations.Add(clickAnimationPlayers[i].animationPlayers);
        }
        allAnimations.Add(backAnimationPlayers);
        allAnimations.Add(exitAnimationPlayers);
        allAnimations.Add(countUpAnimations);
        allAnimations.Add(chargingAnimations);

        for (int i = 0; i< clickAnimationPlayers.Length; i++)
        {
            for (int j = 0; j < allAnimations[i].Length; j++)
            {
                allAnimations[i][j].ResetStatus();
            }
        }

    }

    void PlaySoundOneShot(AudioClip audioClip)
    {
        if (voiceSource != null)
            Destroy(voiceSource.gameObject);
        GameObject gameObject = Instantiate(new GameObject(), Camera.main.transform.position, Quaternion.Euler(Vector3.zero));
        gameObject.transform.SetParent(Camera.main.transform);
        voiceSource = gameObject.AddComponent<AudioSource>();
        voiceSource.playOnAwake = false;
        voiceSource.PlayOneShot(audioClip);
        StartCoroutine(WaitForAudioClipToEnd());
    }

    void StopVoice()
    {
        if (voiceSource != null)
            Destroy(voiceSource.gameObject);
    }

    IEnumerator WaitForAudioClipToEnd()
    {
        while (true)
        {
            if (voiceSource != null && voiceSource.isPlaying)
                yield return null;
            else
                break;
        }

        if (voiceSource != null)
            Destroy(voiceSource.gameObject);
    }





}
