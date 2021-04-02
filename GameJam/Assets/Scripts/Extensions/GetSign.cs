using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExten
{
    public static float GetSign(float value)
    {
        if (value > 0)
            return 1;
        if (value < 0)
            return -1;
        else
            return 0;
    }
    public static int GetSign(int value)
    {
        if (value > 0)
            return 1;
        if (value < 0)
            return -1;
        else
            return 0;
    }
    public static double GetSign(double value)
    {
        if (value > 0)
            return 1;
        if (value < 0)
            return -1;
        else
            return 0;
    }
}
