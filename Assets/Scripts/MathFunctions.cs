using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Assertions.Comparers;

internal class MathFunctions
{
    // TODO: how wrap's working?
    public static float Wrap(float value, float minValue, float maxValue)
    {
        float range = maxValue - minValue;
        return ((value - minValue) % range + range) % range + minValue;
    }

    public static int Wrap(int value, int minValue, int maxValue)
    {
        int range = maxValue - minValue;
        return ((value - minValue) % range + range) % range + minValue;
    }

    public static double Wrap(double value, double minValue, double maxValue)
    {
        double range = maxValue - minValue;
        return ((value - minValue) % range + range) % range + minValue;
    }
}
