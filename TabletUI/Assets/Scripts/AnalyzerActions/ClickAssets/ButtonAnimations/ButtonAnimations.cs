using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ButtonAnimations : MonoBehaviour, IAnimationManager
{
    Animator animator;
    ClickToInteractWithGameObject clickToInteract;

    private void Start()
    {
        animator = GetComponent<Animator>();
        clickToInteract = GetComponentInChildren<ClickToInteractWithGameObject>();
    }

    public float PlayAnimation(int index)
    {
       if (clickToInteract!=null) 
        { 

            if (clickToInteract.index == ClickToInteractWithGameObject.activeIndex)
            {
                animator.Play("FadeOut");
                Debug.Log(gameObject.name + " has faded out");
                ClickToInteractWithGameObject.activeIndex = 0;
            }
            else
            {
                animator.Play("FadeIn");
                Debug.Log(gameObject.name + " has faded in");
            }
        }

       return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
