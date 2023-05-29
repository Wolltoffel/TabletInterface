using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class Screen:MonoBehaviour
{
    [SerializeField] UnityEvent deactiveEvent,activeEvent;
    public void activateScreen()
    {
        activeEvent?.Invoke();
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
    }
    public void deactivateScreen()
    {
        deactiveEvent?.Invoke();
        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }
}
