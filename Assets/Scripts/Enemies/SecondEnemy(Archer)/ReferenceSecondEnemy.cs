using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceSecondEnemy : MonoBehaviour
{
    SecondEnemyBehaviour enemyRef;
    void Start()
    {
        enemyRef = GetComponentInParent<SecondEnemyBehaviour>();
    }

    public void RangeAttack()
    {
        Vector2 posTarget = enemyRef.enemyAttack.playerTransform.position;
        enemyRef.enemyAttack.RangeAttack((int)enemyRef.stats.damage, enemyRef.stats.knockbackForce, enemyRef.firePointRb.transform,posTarget);
    }
}
