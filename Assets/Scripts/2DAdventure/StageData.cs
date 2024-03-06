using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageData
{
    private readonly static Vector2 maxPlayerLimit = new Vector2(122.5f, 25f);
    private readonly static Vector2 minPlayerLimit = new Vector2(-10.5f, -8f);

    private readonly static Vector2 maxCameraLimit = new Vector2(114f, 25f);
    private readonly static Vector2 minCameraLimit = new Vector2(-2f, -8f);

    public static Vector2 MaxPlayerLimit => maxPlayerLimit;
    public static Vector2 MinPlayerLimit => minPlayerLimit;
    public static Vector2 MaxCameraLimit => maxCameraLimit;
    public static Vector2 MinCameraLimit => minCameraLimit;
}
