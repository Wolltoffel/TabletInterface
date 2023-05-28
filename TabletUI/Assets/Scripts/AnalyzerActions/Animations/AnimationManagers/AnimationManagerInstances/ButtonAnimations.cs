using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationSequence
{
    ClickToInteractWithGameObject clickToInteract;
    bool visible;
    enum AnimationDirection {
        left,right
    }
    Collider collider;

    [SerializeField]AnimationDirection animationDirection;

    private IEnumerator Start()
    {
        yield return null;
        yield return null;
        animator = GetComponent<Animator>();
        clickToInteract = GetComponent<ClickToInteractWithGameObject>();
    }

    public override float PlayAnimation(int index)
    {

        if (clickToInteract!=null) 
        {

            if (visible)
            {
                if(animationDirection == AnimationDirection.left)
                    animator.Play("1 FadeOut");
                else
                    animator.Play("2 FadeOut");
                visible = false;

            }
            else
            {

                if (animationDirection == AnimationDirection.left)
                    animator.Play("1 FadeIn");
                else
                    animator.Play("2 FadeIn");
                visible = true;
            }
        }
        return 0;
    }
}
