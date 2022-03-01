using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int heartsAmount;
    public int maxHearts;
    public float movementForce;
    public float distanceTracking;
    public float distanceToAttack;
    public float attackDelay;
    public float attackRadiusArea;
    public int damageHits;
    public float knockbackForce;

    private void Start()
    {
        heartsAmount = maxHearts;
    }
}
