using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AnimationSequenceList
{
    public AnimationSequence[] animationSequences;

    public IEnumerator startAnimationSequence(int index)
    {
        for (int i = 0; i < animationSequences.Length; i++)
        {
            animationSequences[i].PlayAnimation(index);
            float animationDuration = animationSequences[i].animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationDuration);
        }
    }
}
