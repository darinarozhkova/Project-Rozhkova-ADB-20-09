using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Generilized
{
    public List<float> GenerilizedValues;

    public Generilized(int countJoints)
    {
        GenerilizedValues = new List<float>();
        for (int i = 0; i < countJoints; i++)
        {
            GenerilizedValues.Add(0.0f);
        }
    }

    /// <summary>
    /// syntax construction that we can use for Generilized[]...
    /// </summary>
    /// <param name="index">the index of the joints from 0..count - 1</param>
    /// <returns>return angle of the joint</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public float this[int index]
    {
        get
        {
            if (index >= 0 || index <= GenerilizedValues.Count - 1)
            {
                return GenerilizedValues[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        set
        {
            if (index >= 0 || index <= GenerilizedValues.Count - 1)
            {
                GenerilizedValues[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
