using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    AnimationSequence[] animationSequenceList;
    public void updateData(AnimationSequence[] animationSequenceList)
    {
        this.animationSequenceList = animationSequenceList;
    }
    public void goBack()
    {
        int index =  ClickToInteractWithGameObject.activeIndex;
        for (int i = 0; i < animationSequenceList.Length; i++)
        {
            StartCoroutine(animationSequenceList[i].startAnimationSequence(0));
        }
        ClickToInteractWithGameObject.activeIndex = 0;

    }

}
