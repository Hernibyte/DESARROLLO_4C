using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceFirstEnemy : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    EnemyAttack enemyAttack;
    EnemyMovement enemyMovement;

    FirstEnemyBehaviour enemy;

    void Start()
    {
        enemy = GetComponentInParent<FirstEnemyBehaviour>();
        enemyAttack = GetComponentInParent<EnemyAttack>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    public void MeleeAttack()
    {
        enemy.enemyAttack.MeleeAttack(playerLayer);
    }

    public void RestoreMovement()
    {
        enemy.enemyMovement.RestoreMove();
        enemy.SetChaseState();
    }
}
