using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] UnityEvent generateEnemies;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(MyUtilities.Contains(playerMask, other.gameObject.layer))
        {
            generateEnemies?.Invoke();
        }
    }
}
