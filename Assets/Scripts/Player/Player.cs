using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [HideInInspector] public UnityEvent die;

    void Awake() 
    {
        die = new UnityEvent();
    }

    public void CheckIfDie(float lifeAmount)
    {
        if(lifeAmount <= 0)
        {
            die?.Invoke();
        }
    }
}
