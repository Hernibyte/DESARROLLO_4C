using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement movement;

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        stats.lifeAmount -= amountDamage;
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
    }
}
