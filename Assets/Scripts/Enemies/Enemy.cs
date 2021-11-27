using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public UnityEvent die;
    [SerializeField] UnityEvent atDie;

    Collider2D enemyColl;

    void Awake() 
    {
        enemyColl = GetComponent<Collider2D>();
        die = new UnityEvent();
    }

    public void CheckIfDie(float lifeAmount)
    {
        if(lifeAmount <= 0)
        {
            die?.Invoke();
            atDie?.Invoke();
            enemyColl.enabled = false;
        }
    }
}
