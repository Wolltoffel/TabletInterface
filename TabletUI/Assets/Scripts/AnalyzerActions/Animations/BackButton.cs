using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    AnimationSequenceList[] animationSequenceLists;
    public void insertData(AnimationSequenceList[] animationSequenceLists)
    {
        this.animationSequenceLists = animationSequenceLists;
    }
    public void goBack()
    {
        int index =  ClickToInteractWithGameObject.activeIndex;
        StartCoroutine(animationSequenceLists[0].startAnimationSequence(0));
    }

}
