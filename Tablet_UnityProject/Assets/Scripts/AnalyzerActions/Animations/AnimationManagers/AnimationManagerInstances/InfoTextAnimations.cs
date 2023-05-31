using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class InfoTextAnimations: AnimationPlayer
{
    [TextArea]
    [SerializeField] string[] infoTexts;
    [TextArea]
    [SerializeField] string[] headerTexts;
    [TextArea]
    [SerializeField] string[] codeTexts;
    [SerializeField] TextMeshProUGUI headerTextComponent;
    [SerializeField]TextMeshProUGUI infoTextComponent;
    [SerializeField] TextMeshProUGUI codeTextComponent;
    bool fadedIn;

    public override void PlayAnimation(int index)
    { 
        infoTextComponent.text = infoTexts[index - 1];
        headerTextComponent.text = headerTexts[index - 1];
        codeTextComponent.text = codeTexts[index - 1];

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
}
