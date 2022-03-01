using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct MyUtilities
{
    public class MyUnityEvent2F : UnityEvent<float, float>
    {

    }

    public class MyUnityEvent2I : UnityEvent<int, int>
    {
    }

    public class MyUnityEventNoParam : UnityEvent
    {
    }

    public static bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        public virtual void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this as T;
            DontDestroyOnLoad(this);
        }
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