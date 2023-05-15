using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Animator animator;
    [SerializeField]string paramterName;
    bool zoomedIn;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(int index)
    {
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

}
