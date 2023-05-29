using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    AnimationPlayer[] animationSequenceList;
    public void updateData(AnimationPlayer[] animationSequenceList)
    {
        this.animationSequenceList = animationSequenceList;
    }
    public void goBack()
    {
        int index =  ClickToInteractWithGameObject.getActiveIndex();
        InteractionCounter.instance.NoteDownInteraction(index);
        ClickToInteractWithGameObject.setActiveIndex(index);

        for (int i = 0; i < animationSequenceList.Length; i++)
        {
            StartCoroutine(animationSequenceList[i].startAnimationSequence(index));
        }
    }

}
