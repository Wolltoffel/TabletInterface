using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ButtonAnimations : AnimationPlayer
{
    ClickToInteractWithGameObject clickToInteract;
    bool visible;
    enum AnimationDirection {
        left,right
    }

    [SerializeField]AnimationDirection animationDirection;

    private IEnumerator Start()
    {
       //yield return null;
        while(clickToInteract==null||animator==null){
            animator = GetComponent<Animator>();
            clickToInteract = GetComponent<ClickToInteractWithGameObject>();
            yield return null;
        }
    }

    public override float PlayAnimation(int index)
    {
        if (clickToInteract!=null) 
        {

            if (visible)
            {
                if(animationDirection == AnimationDirection.left)
                {
                    Debug.Log("FadeOut 1 " + gameObject.name);
                    animator.Play("1 FadeOut");

                }

                else
                {
                    Debug.Log("FadeOut 2" + gameObject.name);
                    animator.Play("2 FadeOut");
                }
                    
                visible = false;

            }
            else
            {
               
                if (animationDirection == AnimationDirection.left)
                {
                    Debug.Log("FadeIn 1 " + gameObject.name);
                    animator.Play("1 FadeIn");
                }

                else
                {
                    Debug.Log("FadeIn 2 " + gameObject.name);
                    animator.Play("2 FadeIn");
                }
                  
                visible = true;
            }
        }
        return 0;
    }
}
