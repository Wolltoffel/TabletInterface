using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class InfoTextAnimations: AnimationPlayer
{
    [TextArea]
    [SerializeField] string[] infoTexts;
    [SerializeField]TextMeshProUGUI infoTextComponent ;
    bool fadedIn;

    public override void PlayAnimation(int index)
    { 

        infoTextComponent.text = infoTexts[index+1];

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
