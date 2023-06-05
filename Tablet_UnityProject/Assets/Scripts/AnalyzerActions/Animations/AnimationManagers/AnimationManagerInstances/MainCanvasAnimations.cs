using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class MainCanvasAnimations: AnimationPlayer
{
    [TextArea]
    [SerializeField] string[] infoTexts;
    [TextArea]
    [SerializeField] string[] headerTexts;
    [TextArea]
    [SerializeField] string[] codeTexts;

    [SerializeField]string[] reportTexts = new string[2];

    [SerializeField] TextMeshProUGUI headerTextComponent;
    [SerializeField]TextMeshProUGUI infoTextComponent;
    [SerializeField] TextMeshProUGUI codeTextComponent;

    [SerializeField] TextMeshProUGUI reportTextComponent;
    bool fadedIn;
    bool firstFadeIn = true;

    public override void PlayAnimation(int index, bool firstButtonPress)
    {
        int activePresetIndex = GameManager.GiveActivePresetIndex();
        index = activePresetIndex * 3 + index;
        reportTextComponent.text = reportTexts[activePresetIndex];



        if (index > 0)
        {
            infoTextComponent.text = infoTexts[index - 1];
            headerTextComponent.text = headerTexts[index - 1];
            codeTextComponent.text = codeTexts[index - 1];
        }

        if (firstFadeIn)
        {
            animator.Play("SetUpMainCanvas");
            firstFadeIn = false;
            return;
        }

        if (fadedIn)
        {
            animator.Play("FadeOut");
            fadedIn = false;
        }
        else
        {
            fadedIn = true;
            animator.Play("FadeIn");
        }
    }

    public override void SetIndex(int newIndex) { }
    public override void PlayAnimation(int estimatedCost) { }
    public override int GetIndex()
    {
        return 0;
    }

    public override void  ResetStatus()
    {
        fadedIn = false;
        firstFadeIn = true;
    }
}
