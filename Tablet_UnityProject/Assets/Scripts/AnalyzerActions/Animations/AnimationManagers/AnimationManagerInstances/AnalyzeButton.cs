using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnalyzeButton :AnimationPlayer
{
    bool active=false;
    ErrorPreset errorPreset;
    bool pressed = false;

    Sprite activeSprite, passiveSprite;

    public override void PlayAnimation(int estimatedCost) { }

    public void AssignPreset (ErrorPreset preset)
    {
        errorPreset = preset;

        Button button = GetComponent<Button>();

        if (button == null)
            button = gameObject.AddComponent<Button>();

        button.onClick.AddListener(ButtonPress);
    }

    public void AssignSprites(Sprite activeSprite, Sprite passiveSprite) {
        this.activeSprite = activeSprite;
        this.passiveSprite = passiveSprite;
    }

    public void SetActive(bool active) {
        this.active = active;
       
        if (active)
            GetComponent<Image>().sprite = activeSprite;
        else
            GetComponent<Image>().sprite = passiveSprite;
    }

    public void ButtonPress()
    {
        if (active)
        {
            pressed = true;
        }
    }

    public bool GiveButtonState()
    {
        return pressed;
    }

    public void ResetButton()
    {
        pressed=false;
        active = false;
    }

    public override void  PlayAnimation (int index, bool firstButtonPress)
    {
        if (!active) {
            animator.Play("ActiveState");
        }
    }

    public override void SetIndex(int estimatedCost) { }

    public override void ResetStatus() { }
    public override int GetIndex()
    {
        return 0;
    }
}
