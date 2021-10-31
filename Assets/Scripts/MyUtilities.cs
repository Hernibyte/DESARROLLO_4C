using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct MyUtilities
{
    public class MyUnityEvent : UnityEvent<float, float>
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