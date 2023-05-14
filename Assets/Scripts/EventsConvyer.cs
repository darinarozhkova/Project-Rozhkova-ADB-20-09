using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsConvyer : MonoBehaviour
{
    public static Action EnterToRobot;

    public void OnTriggerEnter(Collider other)
    {
        EnterToRobot();
    }
}
