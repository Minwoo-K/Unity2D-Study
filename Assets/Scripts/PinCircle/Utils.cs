using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static Vector3 GetPositionFromAngle(float angle, float radius)
    {
        Vector3 position = Vector3.zero;

        angle = DegreeToRadian(angle);
        position.x = Mathf.Cos(angle) * radius;
        position.y = Mathf.Sin(angle) * radius;

        return position;
    }

    // 180 degree = PI radian : The Conversion Formula
    // 1 degree = PI / 180 radian
    // a degree = PI / 180 * a radian
    // 1 radian = 180 / PI degree
    // a radian = 180 * a / PI degree
    public static float DegreeToRadian(float angle)
    { 
        return Mathf.PI * angle / 180;
    }

    public static float RadianToDegree(float angle)
    {
        return angle * 180 / Mathf.PI;
    }
}
