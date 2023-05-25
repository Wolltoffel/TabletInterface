using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHandler : MonoBehaviour
{

    [SerializeField]UnityEvent loadingScreen;
    [SerializeField] UnityEvent<int> closeUp;

    public void StartLoadingScreenAnimations()
    {
        loadingScreen?.Invoke();
    }

    public void StartCloseUpAnimations(int index)
    {
        closeUp?.Invoke(index);
    }
}
