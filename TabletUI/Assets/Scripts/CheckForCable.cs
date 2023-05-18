using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCable
{
 
    public bool checkForChargingCable() {
        if (SystemInfo.batteryStatus == BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.NotCharging || SystemInfo.batteryStatus == BatteryStatus.Full)
        {
            Debug.Log("Device is plugged in");
            return true;
        }
        return false;
    }
}
