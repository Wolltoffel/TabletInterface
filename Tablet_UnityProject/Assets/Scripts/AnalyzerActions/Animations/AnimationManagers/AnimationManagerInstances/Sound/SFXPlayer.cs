using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXPlayer
    : AnimationPlayer
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        if (audioSource == null ) {
            Debug.LogError("Missing AudioSource on "+gameObject.name);
        }
    }

    public override void PlayAnimation(int index)
    {
        audioSource.PlayOneShot(clips[index]);
    }
}