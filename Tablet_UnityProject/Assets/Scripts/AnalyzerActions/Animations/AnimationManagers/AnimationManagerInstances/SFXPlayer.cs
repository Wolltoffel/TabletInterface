using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SFXPlayer: MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    GameObject audioHolder;
    AudioSource audioSource;


    private void Awake()
    {
        /*audioSource = GetComponent<AudioSource>(); 
        if (audioSource == null ) {
            Debug.LogError("Missing AudioSource on "+gameObject.name);
        }*/
    }

    public void PlayAudio (int audioIndex)
    {
        Destroy(audioHolder);

        if (audioIndex>=clips.Length)
            Debug.LogError(gameObject.name + $" there's no audio clip for index " + audioIndex);

        AudioSource.PlayClipAtPoint(clips[audioIndex], Camera.main.transform.position);

    }


}
