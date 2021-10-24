using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform attackPivot;
    [SerializeField] EnemyStats stats;
    public Transform playerTransform;
    float auxTimer;

    public void SetPivotPosition(Vector2 position)
    {
        attackPivot.position = position;
    }

    public bool MeleeAttack(LayerMask objectiveMask)
    {
        auxTimer += Time.deltaTime;
        if(auxTimer >= stats.attackDelay)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPivot.position, stats.attackRadiusArea, objectiveMask);
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

    public void RangeAttack(int damageDelt, float knockBackForce, Transform position)
    {
        GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform);
        ProjectileBehaviour proj = obj.GetComponent<ProjectileBehaviour>();
        proj.SetValuesAndShoot(damageDelt, knockBackForce, position);
    }
}
