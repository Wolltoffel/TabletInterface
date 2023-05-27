using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoomInCanvasManager: AnimationSequence
{
    ClickToInteractWithGameObject clickToInteract;
    [TextArea]
    [SerializeField] string[] infoTexts;
    [SerializeField]TextMeshProUGUI infoTextComponent ;

    private void Start()
    {
        animator = GetComponent<Animator>();
        clickToInteract = GetComponentInChildren<ClickToInteractWithGameObject>();
    }
    public override float PlayAnimation(int index)
    { 

        infoTextComponent.text = infoTexts[index];

        if (index == ClickToInteractWithGameObject.activeIndex)
        {
            animator.Play("FadeOut");
            ClickToInteractWithGameObject.activeIndex = 0;
            Debug.Log("3 Fade Out Canvas");
        }
        else
        {
            animator.Play("FadeIn");
            Debug.Log("3 Fade In Canvs");
        }
        

    return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
