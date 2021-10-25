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
    [HideInInspector] public UnityEvent imDie;
    bool ifSetPositionPivot;
    Animator enemyAnimator;


    private void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }
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
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) <= stats.distanceTracking)
        {
            state = MyUtilities.EnemyState.Chasing;
            enemyAnimator.SetTrigger("Chase");
        }
    }

    void Chasing()
    {
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) >= stats.distanceTracking)
        {
            state = MyUtilities.EnemyState.Idle;
            enemyAnimator.SetTrigger("Idle");
        }
        //
        if (Vector2.Distance(transform.position, enemyAttack.playerTransform.position) <= stats.distanceToAttack)
        {
            state = MyUtilities.EnemyState.Attacking;
            enemyAnimator.SetTrigger("Attack");
            ifSetPositionPivot = false;
        }
        //
        if(ifSetPositionPivot)
            ifSetPositionPivot = false;
        //
        enemyMovement.Move(enemyAttack.playerTransform.position);
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
            enemyAnimator.SetTrigger("Chase");
        }
    }
}
