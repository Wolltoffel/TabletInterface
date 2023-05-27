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
        if (!zoomedIn)
        {
            animator.SetInteger(paramterName, index);
            zoomedIn = true;
            Debug.Log("2 Zoomed In to number " + index);
        }

        else
        {
            animator.SetInteger(paramterName, 0);
            zoomedIn = false;
            Debug.Log("2 Zoomed Out to number " + index);
        }

        return animator.GetCurrentAnimatorStateInfo(0).length;
    }

}
