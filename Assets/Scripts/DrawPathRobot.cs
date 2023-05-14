using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPathRobot : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;
    public Transform Point3;
    public Transform Point4;

    private void OnDrawGizmos()
    {
        int segmentsNumber = 20;
        Vector3 previousPoint = Point1.position;

        for (int i = 0; i < segmentsNumber; i++)
        {
            float parameter = (float)i / segmentsNumber;
            Vector3 point = Bezier.GetPoint(Point1.position, Point2.position, Point3.position, Point4.position, parameter);
            Gizmos.DrawLine(previousPoint, point);
            previousPoint = point;
        }
    }
}
