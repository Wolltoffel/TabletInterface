using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : AnimationPlayer
{
    [SerializeField]string paramterName;
    bool zoomedIn;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void PlayAnimation(int index)
    {
        index = GameManager.GiveActivePresetIndex() * 3 + index;

        if (!zoomedIn)
        {
            animator.SetInteger(paramterName, index);
            zoomedIn = true;
        }

        else
        {
            animator.SetInteger(paramterName, 0);
            zoomedIn = false;
        }
    }

    public override void PlayLoadInAnimation() { }
    public override void PlayLoadOutAnimation() { }

}
