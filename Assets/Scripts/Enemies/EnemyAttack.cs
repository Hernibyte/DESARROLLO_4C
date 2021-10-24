using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform attackPivot;
    [SerializeField] EnemyStats stats;
    [SerializeField] LayerMask playerMask;
    float auxTimer;

    public void SetPivotPosition(Vector2 position)
    {
        attackPivot.position = position;
    }

    public bool Attack()
    {
        auxTimer += Time.deltaTime;
        if(auxTimer >= stats.attackDelay)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPivot.position, stats.attackRadiusArea, playerMask);
            foreach(Collider2D collider in colliders)
            {
                IHitabble hittable;
                if(collider.TryGetComponent<IHitabble>(out hittable))
                {
                    hittable.ReciveDamage(stats.damage, stats.knockbackForce, transform.position);
                }
            }
            auxTimer = 0f;
            return true;
        }
        return false;
    }
}
