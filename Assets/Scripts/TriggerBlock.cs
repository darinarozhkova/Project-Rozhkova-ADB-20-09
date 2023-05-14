using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBlock : MonoBehaviour
{
    public MobileController MobileControllerRobot;

    private void OnTriggerEnter(Collider other)
    {
        if (MobileControllerRobot.StateRobot != StatesRobot.WaitingForLoading)
        {
            if (MobileControllerRobot.StateRobot == StatesRobot.FinishToPathUnloading)
            {
                MobileControllerRobot.StateRobot = StatesRobot.DrivingBack;
            }
        }
    }
}
