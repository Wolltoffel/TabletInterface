using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationSequence
{
    ClickToInteractWithGameObject clickToInteract;
    bool visible;

    private void Start()
    {
        animator = GetComponent<Animator>();
        clickToInteract = GetComponentInChildren<ClickToInteractWithGameObject>();
    }

    public override float PlayAnimation(int index)
    {
       if (clickToInteract!=null) 
        { 
            if (visible)
            {
                animator.Play("FadeOut");
                visible = false;
            }
            else
            {
                animator.Play("FadeIn");
                visible = true;
            }
        }

       return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
