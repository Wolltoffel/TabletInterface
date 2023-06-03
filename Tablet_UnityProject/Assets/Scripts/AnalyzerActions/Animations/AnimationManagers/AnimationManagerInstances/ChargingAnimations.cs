using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChargingAnimations : AnimationPlayer
{

    [SerializeField] VideoPlayer videoPlayer;

    public IEnumerator PlayVideo()
    {
        PlayAnimation(0, false);
        yield return new WaitForSeconds((float)videoPlayer.length);
    }

    public override void PlayAnimation(int index, bool firstButtonPress)
    {
        videoPlayer.Play();
    }

    public override void PlayAnimation(int estimatedCosts)
    {
    }

    public override void SetIndex(int newIndex)
    {
    }

    public override int GetIndex()
    {
        return 0;
    }
}
