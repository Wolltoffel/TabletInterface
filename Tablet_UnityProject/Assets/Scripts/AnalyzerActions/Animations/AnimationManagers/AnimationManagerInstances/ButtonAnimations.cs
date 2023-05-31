using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationPlayer
{
    bool visible;
    int index;
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
        else
        {
            if (hasBeenClicked)
            {
                if (animationDirection == AnimationDirection.left)
                {
                    animator.Play("1 FadeInFirst");
                }

                else
                {
                    animator.Play("2 FadeInFirst");
                }
            }
            else
            {
                Debug.Log("Default Fade In for " + gameObject.name);
                if (animationDirection == AnimationDirection.left)
                {
                    animator.Play("1 FadeIn");
                }

                else
                {
                    animator.Play("2 FadeIn");
                }
            }
    
            visible = true;
        }
    }

}
