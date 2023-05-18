using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckForCable : MonoBehaviour
{
   [SerializeField] UnityEvent startScene;

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.batteryStatus==BatteryStatus.Charging||SystemInfo.batteryStatus==BatteryStatus.NotCharging|| SystemInfo.batteryStatus == BatteryStatus.Full)
        {
            startScene?.Invoke();
            Debug.Log("Device Is Plugged In");
        }
    }
}
