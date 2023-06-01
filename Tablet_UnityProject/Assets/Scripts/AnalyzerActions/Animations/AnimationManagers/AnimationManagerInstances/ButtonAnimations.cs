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
    bool hasBeenClickedAtLeastOnce;

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
        string animationName = "";

        //Set animation direction
        if (animationDirection == AnimationDirection.left)
            animationName = "Left_";
        else
            animationName = "Right_";

        //Set animationkind
        if (visible)
            animationName = animationName+ FadeOutAnimations();
        else
            animationName = animationName+FadeInAnimations(hasBeenClicked);

        //Play animation
        animator.Play(animationName);
    }

    string FadeOutAnimations()
    {
        visible = false;
        if (hasBeenClickedAtLeastOnce)
            return "FadeOutAlreadySelected";
        else
            return "FadeOutDefault";
    }

    string FadeInAnimations(bool hasBeenClicked)
    {
        visible = true;

        if (hasBeenClicked)
            return HasBeenClickedAnimations();

        else
            return "FadeInDefault";   
    }

    string HasBeenClickedAnimations()
    {
        if (hasBeenClickedAtLeastOnce)
            return "FadeInAlreadySelected";
        else
        {
            hasBeenClickedAtLeastOnce = true;
            return "FadeInTransition";
        }
    }
 }
   
