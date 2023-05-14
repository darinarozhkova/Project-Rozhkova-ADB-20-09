using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public List<string> RobotInformation;
    public GameObject[] JointsObjects;
    public List<float> JointsValues;

    Generilized targetGenerilized;
    Generilized tempGenerilized;

    private void Start()
    {
        if (JointsObjects.Length != JointsValues.Count)
        {
            throw new System.Exception("Count the joint objects must be equal joint values list.");
        }

        targetGenerilized = new Generilized(JointsValues.Count);
        tempGenerilized = new Generilized(JointsValues.Count);
    }

    private void Update()
    {
        for (int i = 0; i < JointsValues.Count; i++)
        {
            targetGenerilized[i] = Mathf.Deg2Rad * JointsValues[i];
        }

        UpdateGenerilized(Time.deltaTime);
        
        for (int i = 0; i < JointsValues.Count; i++)
        {
            var tempAngle = Mathf.Rad2Deg * tempGenerilized[i];
            SetAngleOfJoint(JointsObjects[i], tempAngle);
        }
    }

    /// <summary>
    /// Set angle for the joint of the robot. Axis rotation we will take how z axis.
    /// </summary>
    /// <param name="jointObject">Gameobject that will be a joint of the robot.</param>
    /// <param name="axisRotate">Axis rotate of the robot (x, y, z)</param>
    /// <param name="angleRotation">Angle rotation of the robot (degrees)</param>
    public void SetAngleOfJoint(GameObject jointObject, float angleRotation)
    {
        Quaternion localRotationObj = jointObject.transform.localRotation;
        float x = localRotationObj.eulerAngles.x;
        float y = localRotationObj.eulerAngles.y;

        jointObject.transform.localRotation = Quaternion.Euler(x, y, angleRotation);
    }

    // TODO: explain myself how it works.
    public void UpdateGenerilized(float deltaTime)
    {
        Generilized velocities = MaximumJointVelocity(80);

        for (int i = 0; i < JointsValues.Count; i++)
        {
            float deltaGeneralized = MathFunctions.Wrap(
                targetGenerilized[i] -  tempGenerilized[i],
                -Mathf.PI,
                Mathf.PI
            );
            if (
                Mathf.Abs(deltaGeneralized) >
                velocities[i] * deltaTime + Mathf.Epsilon
            )
            {
                tempGenerilized[i] +=
                    Mathf.Sign(deltaGeneralized) * velocities[i] * deltaTime;
            }
            else
            {
                tempGenerilized[i] += deltaGeneralized;
            }
        }
    }

    /// <summary>
    /// Set default value of the velocities joints. For example: 80
    /// </summary>
    /// <returns>Generilized with velocities.</returns>
    public Generilized MaximumJointVelocity(int valueMaxVelocity)
    {
        Generilized maximumVelocityGenerilized = new Generilized(JointsValues.Count);
        for (int i = 0; i < JointsValues.Count; i++)
        {
            maximumVelocityGenerilized[i] = valueMaxVelocity * Mathf.Deg2Rad;
        }

        return maximumVelocityGenerilized;
    }

    /// <summary>
    /// Set values of maximum velocity for the robot. You need transfer the float list of velocities.
    /// </summary>
    /// <returns>Generilized with velocities.</returns>
    public Generilized MaximumJointVelocity(List<float> maxVelocitiesList)
    {
        if (maxVelocitiesList.Count != JointsValues.Count)
        {
            throw new System.Exception(" max velocities list count must be equal joint velocities");
        }

        Generilized maxVelocities = new Generilized(maxVelocitiesList.Count);

        for (int i = 0; i < maxVelocitiesList.Count; i++)
        {
            maxVelocities[i] = maxVelocitiesList[i] * Mathf.Deg2Rad;
        }

        return maxVelocities;
    }

    /// <summary>
    /// This is function that returns the basic position of the robot.
    /// The full information you can get in the documentation.
    /// </summary>
    public void GetNullPosition()
    {
        // TODO: reading from the source list joints and set it to the robot.
    }

    /// <summary>
    /// Return count of the joints in the robot.
    /// </summary>
    /// <returns>count of the joins.</returns>
    public int GetCountJoints()
    {
        return JointsValues.Count;
    }
}
