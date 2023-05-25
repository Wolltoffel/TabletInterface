using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;


public class ClickToInteractWithGameObject : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public int index;
    public static int activeIndex = 0;
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

        backButton.updateData(animationSequenceList.animationSequences);

    }

    public void InsertSetUpData(int index, AnimationSequenceList animationSequenceList, BackButton backButton)
    {
        this.index = index;
        this.animationSequenceList = animationSequenceList;
        this.backButton = backButton;
    }

    
 }




