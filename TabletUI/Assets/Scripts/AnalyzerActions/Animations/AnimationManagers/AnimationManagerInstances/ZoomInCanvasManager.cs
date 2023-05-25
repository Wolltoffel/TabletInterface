using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInCanvasManager: AnimationSequence
{
    ClickToInteractWithGameObject clickToInteract;

    private void Start()
    {
        animator = GetComponent<Animator>();
        clickToInteract = GetComponentInChildren<ClickToInteractWithGameObject>();
    }
    public override float PlayAnimation(int index)
    { 
        if (index == ClickToInteractWithGameObject.activeIndex)
        {
            animator.Play("FadeOut");
            ClickToInteractWithGameObject.activeIndex = 0;
        }
        else
        {
            animator.Play("FadeIn");
        }
        

    return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
