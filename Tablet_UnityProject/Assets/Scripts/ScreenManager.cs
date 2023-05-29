using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScreenManager: MonoBehaviour
{
    [SerializeField] Screen[] screens;
    Screen activeScreen;

    void Awake()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (i!=0)
                screens[i].deactivateScreen();
        }

        //LoadFirstScene
        activeScreen = screens[0];
        screens[0].activateScreen();
    }

    public void switchScreen(string sceneName)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (screens[i].name == sceneName && screens[i].isActiveAndEnabled == false)
            {
                activeScreen.deactivateScreen();
                screens[i].activateScreen();
                activeScreen = screens[i];
            }       
        }
    }
}
