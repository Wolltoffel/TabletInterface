using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;
using System;


public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public int index;
    public static int activeIndex;
    AnimationSequenceList animationSequenceList;
    BackButton backButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        activeIndex = index;
        StartCoroutine(handleAction());

    }

    IEnumerator handleAction()
    {
        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            yield return animationSequenceList.animationSequences[i].startAnimationSequence(index);
        }

        backButton.updateData(reverseAnimationOrder());

    }

    public void InsertSetUpData(int index, AnimationSequenceList animationSequenceList, BackButton backButton)
    {
        this.index = index;
        this.animationSequenceList = animationSequenceList;
        this.backButton = backButton;
    }

    AnimationSequence[] reverseAnimationOrder()
    {
        AnimationSequence[] forward = animationSequenceList.animationSequences;
        AnimationSequence[] reversed = new AnimationSequence[forward.Length];
        Array.Copy(forward,reversed,forward.Length);

        Array.Reverse(reversed);

        return reversed;
    }

    
 }




