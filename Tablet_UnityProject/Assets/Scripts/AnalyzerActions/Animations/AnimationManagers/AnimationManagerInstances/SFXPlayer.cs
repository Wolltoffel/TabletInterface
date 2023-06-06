using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXPlayer: MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        /*audioSource = GetComponent<AudioSource>(); 
        if (audioSource == null ) {
            Debug.LogError("Missing AudioSource on "+gameObject.name);
        }*/
    }

    public void PlayAudio (int audioIndex)
    {
        if (audioIndex>=clips.Length)
            Debug.LogError(gameObject.name + $" there's no audio clip for index " + audioIndex);

        audioSource.PlayOneShot(clips[audioIndex]);
    }
    
}
