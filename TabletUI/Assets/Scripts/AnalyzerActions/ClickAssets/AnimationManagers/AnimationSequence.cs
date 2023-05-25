using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationSequence : MonoBehaviour
{
    [HideInInspector]public Animator animator;
    public abstract float PlayAnimation(int index);
}
