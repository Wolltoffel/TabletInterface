using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerTester : AnimationPlayer
{

    public override void PlayAnimation(int a, bool firstButtonPress)
    {
        animator = GetComponent<Animator>();
        animator.Play("1 FadeIn");
        Debug.Log("test");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // PlayAnimation(0);
        }
    }

    public override void SetIndex(int newIndex) { }
    public override void PlayAnimation(int estimatedCost) { }
    public override void ResetStatus() { }
    public override int GetIndex()
    {
        return 0;
    }

}
