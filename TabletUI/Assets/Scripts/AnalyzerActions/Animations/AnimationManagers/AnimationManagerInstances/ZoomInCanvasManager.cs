using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoomInCanvasManager: AnimationSequence
{
    ClickToInteractWithGameObject clickToInteract;
    [TextArea]
    [SerializeField] string[] infoTexts;
    [SerializeField]TextMeshProUGUI infoTextComponent ;
    bool fadedIn;

    private void Start()
    {
        animator = GetComponent<Animator>();
        clickToInteract = GetComponentInChildren<ClickToInteractWithGameObject>();
    }
    public override float PlayAnimation(int index)
    { 

        infoTextComponent.text = infoTexts[index];

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
        

    return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
