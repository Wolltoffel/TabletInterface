using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    ErrorPreset preset;
    bool active = true;

    public void AssignPreset(ErrorPreset preset)
    {
        this.preset = preset;

        Button button = GetComponent<Button>();

        if (button == null)
            button = gameObject.AddComponent<Button>();

        button.onClick.AddListener(ButtonPress);
    }

    public void ButtonPress()
    {
        if (active)
        {
            preset.GoBack();
        }
        active = false;
    }

    public void SetActive(bool active)
    {
        this.active = active;
    }

}
