using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement movement;
    [SerializeField] Enemy enemy;
    public MyUtilities.MyUnityEvent hasRecivedDamage = new MyUtilities.MyUnityEvent();

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        stats.distanceTracking = 80;

        stats.lifeAmount -= amountDamage;
        hasRecivedDamage?.Invoke(stats.lifeAmount, stats.maxLife);
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
        enemy.CheckIfDie(stats.lifeAmount);
    }
}
