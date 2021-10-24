using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] List<GameObject> enemiesPrefab;
    [SerializeField] UnityEvent switchDoorsOpen;
    [HideInInspector] public int enemiesAmount;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(MyUtilities.Contains(playerMask, other.gameObject.layer))
        {
            GenerateEnemies();
            switchDoorsOpen?.Invoke();
            enemiesAmount++;
        }
    }

    void GenerateEnemies()
    {

    }

    public void IfEnemyDie()
    {
        enemiesAmount--;
        if(enemiesAmount <= 0)
            switchDoorsOpen?.Invoke();
    }
}
