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


    // 180 degree = PI radian
    // 1 degree = PI / 180 radian
    // a degree = a * PI / 180 radian
    // 1 radian = 180 / PI degree
    // a radian = a * 180 / PI degree
    public static float DegreeToRadian(float angle)
    {
        return angle * Mathf.PI / 180;
    }

    public static float RadianToDegree(float angle)
    {
        return angle * 180 / Mathf.PI;
    }
}
