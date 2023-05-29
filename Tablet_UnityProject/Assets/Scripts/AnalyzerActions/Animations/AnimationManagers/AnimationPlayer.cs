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

    public abstract void PlayAnimation(int index);

    public IEnumerator startAnimationSequence(int index)
    {
        PlayAnimation(index);
        float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration);
    }
}