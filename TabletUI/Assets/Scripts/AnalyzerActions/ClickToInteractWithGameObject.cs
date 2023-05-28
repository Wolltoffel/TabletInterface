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
    static int activeIndex;
    AnimationSequenceList animationSequenceList;
    BackButton backButton;

    void Start()
    {
        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            if (animationSequenceList.animationSequences[i] is ButtonAnimations) {
                animationSequenceList.animationSequences[i].PlayAnimation(index);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        activeIndex = index;
        StartCoroutine(HandleAction());
    }

    IEnumerator HandleAction()
    {
        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            yield return animationSequenceList.animationSequences[i].startAnimationSequence(index);
        }

        backButton.updateData(ReverseAnimationOrder());

    }

    public void InsertSetUpData(int index, AnimationSequenceList animationSequenceList, BackButton backButton)
    {
        this.index = index;
        this.animationSequenceList = animationSequenceList;
        this.backButton = backButton;
    }

    AnimationSequence[] ReverseAnimationOrder()
    {
        AnimationSequence[] forward = animationSequenceList.animationSequences;
        AnimationSequence[] reversed = new AnimationSequence[forward.Length];
        Array.Copy(forward,reversed,forward.Length);

        Array.Reverse(reversed);

        return reversed;
    }

    public static void setActiveIndex(int index)
    {
        activeIndex = index;
    }

    public static int getActiveIndex()
    {
        return activeIndex;
    }

    
 }




