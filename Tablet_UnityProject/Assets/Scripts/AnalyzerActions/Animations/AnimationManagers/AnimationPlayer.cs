using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AnimationPlayer : MonoBehaviour
{
    [HideInInspector]public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public abstract void PlayAnimation(int index, bool firstButtonPress);

    public IEnumerator startAnimationSequence(int index, bool firstButtonPress)
    {
        if (animator != null)
        {
            PlayAnimation(index,firstButtonPress);
            if (!(this.GetType() == typeof(ButtonAnimations)))
            {
                float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(animationDuration);
            }
        }
        
    }
}