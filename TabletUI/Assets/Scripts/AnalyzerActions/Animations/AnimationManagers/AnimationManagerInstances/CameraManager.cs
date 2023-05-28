using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : AnimationSequence
{
    [SerializeField]string paramterName;
    bool zoomedIn;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override float PlayAnimation(int index)
    {
        index = HoverManager.instance.GetActiveAndroidIndex() * 3 + index;

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

        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

}
