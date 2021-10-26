using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] UnityEvent generateEnemies;

    public void CallGenerateEnemiesEvent()
    {
        generateEnemies?.Invoke();
    }
}
