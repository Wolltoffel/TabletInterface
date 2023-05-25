using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidSelector : MonoBehaviour
{
    List<GameObject> clickables;
    List<GameObject> visitedClickables;

    private void Awake()
    {
        clickables = new List<GameObject>();
        visitedClickables = new List<GameObject>();
    }

    public void AddActiveHoverSessionData(GameObject[] clickables)
    {
        this.clickables.AddRange (clickables);
    }

    public void NoteDownInteraction(int hoverInformation)
    {
        int index = hoverInformation;

        //Check whether the button is already in list
        for (int i = 0;i<visitedClickables.Count;i++)
        {
            if (visitedClickables[i] == clickables[index]) {
                return;
            }
        }

        //Add Button to visitedButtons
        visitedClickables.Add(clickables[index]);

        if (visitedClickables.Count >= clickables.Count)
            SwitchToNextAction();

    }

    void SwitchToNextAction() {
        Debug.Log("All Places visited");
    }
}
