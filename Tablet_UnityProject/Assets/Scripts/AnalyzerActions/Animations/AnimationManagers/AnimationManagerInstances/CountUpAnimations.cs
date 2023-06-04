using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountUpAnimations : AnimationPlayer
{
    [SerializeField] UpCount upCounter;
    int estimatedCost;
    public override void PlayAnimation(int estimatedCost)
    {
        animator.Play("CountUp");
        this.estimatedCost = estimatedCost;
    }

    public void countUpSum()
    {
        upCounter.StartCountUpAnimaton(estimatedCost);
    }

    public void EmptyCountUpAnmimation()
    {
        upCounter.EmptyCountUpAnimaton();
    }
    public override void ResetStatus(){}
    public override int GetIndex() { return 0; }
    public override void PlayAnimation(int index, bool firstButtonPress) { }
    public override void SetIndex(int newIndex) { }

}
