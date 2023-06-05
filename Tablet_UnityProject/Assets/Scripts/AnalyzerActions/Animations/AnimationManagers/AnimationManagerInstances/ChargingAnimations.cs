using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChargingAnimations : AnimationPlayer
{

    [SerializeField] VideoPlayer videoPlayer;

    public void StartVideo()
    {
        videoPlayer.Play();
    }

    public override void PlayAnimation(int index, bool firstButtonPress)
    {
        animator.Play("ChargeScale");
    }

    public override void PlayAnimation(int estimatedCosts)
    {
    }

    public override void SetIndex(int newIndex)
    {
    }

    public override void ResetStatus()
    {
    }

    public override int GetIndex()
    {
        return 0;
    }
}
