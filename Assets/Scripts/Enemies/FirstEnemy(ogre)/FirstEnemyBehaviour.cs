using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstEnemyBehaviour : MonoBehaviour
{
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] EnemyAttack enemyAttack;
    [SerializeField] LayerMask playerMask;
    [SerializeField] MyUtilities.EnemyState state;
    public Transform playerTransform;
    [HideInInspector] public UnityEvent imDie;
    bool ifSetPositionPivot;

    void Update()
    {
        switch(state)
        {
            case MyUtilities.EnemyState.Idle:
                Idle();
            break;
            case MyUtilities.EnemyState.Chasing:
                Chasing();
            break;
            case MyUtilities.EnemyState.Attacking:
                Attacking();
            break;
        }
    }

    void Idle()
    {
        if(Vector2.Distance(transform.position, playerTransform.position) <= stats.distanceTracking)
            state = MyUtilities.EnemyState.Chasing;
    }

    void Chasing()
    {
        if(Vector2.Distance(transform.position, playerTransform.position) >= stats.distanceTracking)
            state = MyUtilities.EnemyState.Idle;
        //
        if(Vector2.Distance(transform.position, playerTransform.position) <= stats.distanceToAttack)
        {
            state = MyUtilities.EnemyState.Attacking;
            ifSetPositionPivot = false;
        }
        //
        if(ifSetPositionPivot)
            ifSetPositionPivot = false;
        //
        enemyMovement.Move(playerTransform.position);
    }

    void Attacking()
    {
        if(!ifSetPositionPivot)
            enemyAttack.SetPivotPosition(transform.position);
        //
        if(enemyAttack.MeleeAttack(playerMask))
        {
            ifSetPositionPivot = true;
            state = MyUtilities.EnemyState.Chasing;
        }
    }
}
