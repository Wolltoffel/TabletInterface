using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTester : MonoBehaviour
{
    public ButtonAnimations tester;

    void Update()
    {
       Debug.Log (tester.enabled);
    }
}
