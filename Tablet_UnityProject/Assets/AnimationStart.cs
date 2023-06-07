using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStart : MonoBehaviour
{
    [SerializeField]GameObject gameObject;

    public void startAnimation()
    {
        gameObject.SetActive(true);
    }
}
