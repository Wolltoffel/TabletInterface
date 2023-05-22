using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class CheckForCable
{
    public bool checkForChargingCable() {
        if (SystemInfo.batteryStatus == BatteryStatus.Charging || SystemInfo.batteryStatus == BatteryStatus.NotCharging || SystemInfo.batteryStatus == BatteryStatus.Full)
        {
            return true;
        }
        return false;
    }
}
