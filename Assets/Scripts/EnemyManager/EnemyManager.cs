using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemiesPrefab;
    [SerializeField] UnityEvent switchGatesOpen;
    [HideInInspector] public int enemiesAmount;
    GameManager gameManager;

    void Awake() 
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GenerateEnemies()
    {
        switchGatesOpen?.Invoke();
        enemiesAmount++;
        //Cuando genero el enemigo puedo enviarle la referencia del player a travez del gameManager
    }

    public void IfEnemyDie()
    {
        enemiesAmount--;
        if(enemiesAmount <= 0)
            switchGatesOpen?.Invoke();
    }
}
