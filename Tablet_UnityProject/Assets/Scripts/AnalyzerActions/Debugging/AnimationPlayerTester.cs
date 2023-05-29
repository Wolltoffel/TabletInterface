using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerTester : AnimationPlayer
{

    public override void PlayAnimation(int a)
    {
        animator = GetComponent<Animator>();
        animator.Play("1 FadeIn");
        Debug.Log("test");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayAnimation(0);
        }
    }

}
