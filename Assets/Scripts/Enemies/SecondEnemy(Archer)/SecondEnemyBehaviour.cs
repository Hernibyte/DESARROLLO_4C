using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecondEnemyBehaviour : MonoBehaviour
{
    public EnemyStats stats;
    [SerializeField] EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    [SerializeField] LayerMask playerMask;
    [SerializeField] MyUtilities.EnemyState state;
    public Rigidbody2D firePointRb;
    [SerializeField] float firePointOffSet;
    [HideInInspector] public UnityEvent imDie;
    //
    float auxTimer;
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
            case MyUtilities.EnemyState.Tracking:
                Tracking();
            break;
            case MyUtilities.EnemyState.Placing:
                Placing();
            break;
            case MyUtilities.EnemyState.Attacking:
                Attacking();
            break;
        }
    }

    void Idle()
    {
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) <= stats.distanceTracking)
            state = MyUtilities.EnemyState.Tracking;
    }

    void Tracking()
    {
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) >= stats.distanceTracking)
        {
            state = MyUtilities.EnemyState.Idle;
            enemyAnimator.SetTrigger("Idle");
        }
        //
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) <= stats.distanceToAttack)
        {
            state = MyUtilities.EnemyState.Attacking;
        }
    }

    void Placing()
    {
        auxTimer += Time.deltaTime;
        if(auxTimer >= 1f)
        {
            auxTimer = 0f;
            state = MyUtilities.EnemyState.Attacking;
        }
    }

    void Attacking()
    {
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) >= stats.distanceToAttack)
            state = MyUtilities.EnemyState.Tracking;
        //
        Vector2 directionShoot = enemyAttack.playerTransform.position - new Vector3(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(directionShoot.y,directionShoot.x) * Mathf.Rad2Deg - 90f;
        firePointRb.rotation = angle;
        //
        auxTimer += Time.deltaTime;
        if(auxTimer >= 2f)
        {
            auxTimer = 0f;
            //
            enemyAnimator.SetTrigger("Attack");
            //
            if(Random.Range(0, 4) == 0)
                state = MyUtilities.EnemyState.Placing;
        }
    }
}
