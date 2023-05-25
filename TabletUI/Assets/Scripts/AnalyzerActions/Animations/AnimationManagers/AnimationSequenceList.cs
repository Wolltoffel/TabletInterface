using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AnimationSequenceList
{
    public AnimationSequence[] animatinSequences;

    public IEnumerator startAnimationSequence(int index)
    {
        for (int i = 0; i < animatinSequences.Length; i++)
        {
            animatinSequences[i].PlayAnimation(index);
            float animationDuration = animatinSequences[i].animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationDuration);
        }
    }
}
