using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;

    public float VelocityRobot;

    public float Position0To1 = 0f;

    private bool ObjectIsSetted = false;
    public GameObject SettedObject;

    public StatesRobot StateRobot;

    public void Start()
    {
        EventsConvyer.EnterToRobot = ForwardToEnd;
        StateRobot = StatesRobot.WaitingForLoading;
    }

    public void Update()
    {
        if (StateRobot == StatesRobot.DrivingForward)
        {
            ForwardToEnd();
            SettedObject.transform.position = transform.position;
        } else if (StateRobot == StatesRobot.DrivingBack)
        {
            BackToStart();
        }
    }

    public void Movement()
    {
        transform.position = Bezier.GetPoint(Point1.position, Point2.position, Point3.position, Point4.position, Position0To1);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(Point1.position, Point2.position, Point3.position, Point4.position, Position0To1));
    }

    public void ForwardToEnd()
    {
        if (Position0To1 != 1)
        {
            Movement();
            ForwardMovement();
        }
    }

    public void BackToStart()
    {
        if (Position0To1 != 0)
        {
            Movement();
            BackMovement();
        }
    }

    public void ForwardMovement()
    {
        Position0To1 += VelocityRobot * Time.deltaTime;
    }

    public void BackMovement()
    {
        Position0To1 -= VelocityRobot * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("ManObj"))
        {
            StateRobot = StatesRobot.DrivingForward;
            SettedObject = other.gameObject;
            SettedObject.GetComponent<Rigidbody>().useGravity = false;
            SettedObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
