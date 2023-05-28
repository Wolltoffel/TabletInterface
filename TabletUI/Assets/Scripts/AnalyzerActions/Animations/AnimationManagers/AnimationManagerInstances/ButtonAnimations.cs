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
                if(index == 1 || index == 4 || index == 6)
                    animator.Play("1 FadeOut");
                else
                    animator.Play("2 FadeOut");
                visible = false;
            }
            else
            {
                if (index == 1 || index == 4 || index == 6)
                    animator.Play("1 FadeIn");
                else
                    animator.Play("2 FadeIn");

                visible = true;
            }
        }

       return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
