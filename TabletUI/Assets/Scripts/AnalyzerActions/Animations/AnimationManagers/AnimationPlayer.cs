using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AnimationPlayer : MonoBehaviour
{
    [HideInInspector]public Animator animator;
    public abstract float PlayAnimation(int index);

    public IEnumerator startAnimationSequence(int index)
    {
        PlayAnimation(index);
        float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration);
    }

    public void startAnimationSequenceWithoutDelay(int index)
    {
        PlayAnimation(index);
    }

}

