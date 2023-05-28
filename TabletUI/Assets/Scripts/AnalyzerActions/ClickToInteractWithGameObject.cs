using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;
using System;
using Unity.VisualScripting;

public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public int index;
    static int activeIndex;
    AnimationSequenceList animationSequenceList;
    BackButton backButton;
    AnimationSequenceList exitZoomAnimations;

   IEnumerator Start()
    {
        yield return null;
        yield return null;
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

        //Build Animation list for Backbutton
        List<AnimationSequence> backButtonList = new List<AnimationSequence>();

        backButtonList.AddRange(ReverseAnimationOrder());
        backButtonList.AddRange(exitZoomAnimations.animationSequences);
        backButton.updateData(backButtonList.ToArray());
        //HoverManager.instance.deactivateAllColliders();

        for (int i = 0; i < exitZoomAnimations.animationSequences.Length; i++)
        {
            exitZoomAnimations.animationSequences[i].startAnimationSequenceWithoutDelay(index);
        }

        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            yield return animationSequenceList.animationSequences[i].startAnimationSequence(index);
        }


        HoverManager.instance.activateAllColliders();

    }

    public void InsertSetUpData(int index, AnimationSequenceList animationSequenceList, BackButton backButton, AnimationSequenceList exitZoomAnimations)
    {
        this.index = index;
        this.animationSequenceList = animationSequenceList;
        this.backButton = backButton;
        this.exitZoomAnimations = exitZoomAnimations;
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




