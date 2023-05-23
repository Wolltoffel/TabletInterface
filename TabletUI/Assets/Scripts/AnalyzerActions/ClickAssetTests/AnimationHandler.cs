using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationHandler : MonoBehaviour
{

    [SerializeField]UnityEvent loadingScreen;
    [SerializeField] UnityEvent<int> closeUp;

    void StartLoadingScreenAnimations()
    {
        loadingScreen?.Invoke();
    }

    void StartCloseUpAnimations(int index)
    {
        closeUp?.Invoke(index);
    }
}
