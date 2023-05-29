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
    AnimationPlayerList animationSequenceList;
    BackButton backButton;
    AnimationPlayerList exitZoomAnimations;

    public IEnumerator startAnimations()
    {
        yield return null;
        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            if (animationSequenceList.animationSequences[i] is ButtonAnimations)
            {
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
 
        UpdateBackButton();


        for (int i = 0; i < exitZoomAnimations.animationSequences.Length; i++)
        {
            exitZoomAnimations.animationSequences[i].startAnimationSequenceWithoutDelay(index);
        }

        for (int i = 0; i < animationSequenceList.animationSequences.Length; i++)
        {
            yield return animationSequenceList.animationSequences[i].startAnimationSequence(index);
        }

    }

    public void InsertSetUpData(int index, AnimationPlayerList animationSequenceList, BackButton backButton, AnimationPlayerList exitZoomAnimations)
    {
        this.index = index;
        this.animationSequenceList = animationSequenceList;
        this.backButton = backButton;
        this.exitZoomAnimations = exitZoomAnimations;
    }

    AnimationPlayer[] ReverseAnimationOrder()
    {
        AnimationPlayer[] forward = animationSequenceList.animationSequences;
        AnimationPlayer[] reversed = new AnimationPlayer[forward.Length];
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

    void UpdateBackButton()
    {
        List<AnimationPlayer> backButtonList = new List<AnimationPlayer>();

        //Get excluded types
        List<Type> excludedTypes = new List<Type>();

        for (int i = 0; i < exitZoomAnimations.animationSequences.Length; i++)
        {
            excludedTypes.Add(exitZoomAnimations.animationSequences.GetType());
        }

        //Sort out excluded types
        List<AnimationPlayer> reversedSequences = new List<AnimationPlayer>();
        reversedSequences.AddRange(ReverseAnimationOrder());

        for (int i = 0; i < reversedSequences.Count; i++)
        {
            for (int j = 0; j < excludedTypes.Count; j++)
            {
                if (excludedTypes[j].GetType() == reversedSequences[i].GetType())
                {
                    reversedSequences.Remove(reversedSequences[i]);
                }
            }
        }

        backButtonList.AddRange(reversedSequences);
        backButtonList.AddRange(exitZoomAnimations.animationSequences);
        backButton.updateData(backButtonList.ToArray());
    }
    
 }




