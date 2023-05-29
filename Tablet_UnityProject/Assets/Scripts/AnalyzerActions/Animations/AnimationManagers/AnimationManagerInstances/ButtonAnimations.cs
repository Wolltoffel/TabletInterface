using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationPlayer
{
    bool visible;
    enum AnimationDirection {
        left,right
    }

    [SerializeField]AnimationDirection animationDirection;

    public override void PlayAnimation(int index)
    {
        Debug.Log ("Playing on "+ gameObject.name);

        if (visible)
        {
            if(animationDirection == AnimationDirection.left)
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
            if (animationDirection == AnimationDirection.left)
            {
                animator.Play("1 FadeIn");
            }

            else
            {
                animator.Play("2 FadeIn");
            }
                  
            visible = true;
        }
    }
}