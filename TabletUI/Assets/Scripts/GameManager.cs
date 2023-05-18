using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CheckForCable checkForCable = new CheckForCable();

    private IEnumerator Start()
    {
        if (checkForCable.checkForChargingCable())
        {
            //Switch from StartScreen to Scene
        }

        while (checkForCable.checkForChargingCable())
        {
            yield return new WaitForSeconds(1);
        }

        //Show Startscreen

        Debug.Log("LoadingStartScreen");

        //Loading Screen
        yield return new WaitForSeconds(2);
        //Load Buttons
        //Switch Buttons
        //Load Buttons
    }
}
