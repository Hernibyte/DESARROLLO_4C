using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct MyUtilities
{
    public class MyUnityEvent2F : UnityEvent<float, float>
    {
    }

    public class MyUnityEventNoParam : UnityEvent
    {
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    public enum EnemyState
    {
        Idle,
        Chasing,
        Tracking,
        Placing,
        Attacking
    }
}