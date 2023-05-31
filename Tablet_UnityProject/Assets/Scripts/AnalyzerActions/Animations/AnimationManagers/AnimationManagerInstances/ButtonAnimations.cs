using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationPlayer
{
    bool visible;
    int index;

    [SerializeField] GameObject exclamationMark;

    enum AnimationDirection {
        left,right
    }

    [SerializeField]AnimationDirection animationDirection;

    public override void SetIndex(int newIndex)
    {
        index = newIndex;
    }

    public override int GetIndex() {
        return index;
    }
    public override void PlayAnimation(int index, bool hasBeenClicked)
    {
        if (visible)
            FadeOutAnimations();
        else
            FadeInAnimations(hasBeenClicked);
    }

    void FadeOutAnimations()
    {
        if (animationDirection == AnimationDirection.left)
        {
            animator.Play("1 FadeOut");
        }

        else
        {
            animator.Play("2 FadeOut");
        }

        visible = false;
    }


    void FadeInAnimations(bool hasBeenClicked)
    {
        if (hasBeenClicked)
        {
            if (exclamationMark != null)
                Destroy(exclamationMark);

            if (animationDirection == AnimationDirection.left)
                animator.Play("1 FadeInFirst");

            else
                animator.Play("2 FadeInFirst");
        }
        else
        {
            if (animationDirection == AnimationDirection.left)
                animator.Play("1 FadeIn");

            else
                animator.Play("2 FadeIn");
        }

        visible = true;
    }
    }
   
