using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstEnemyBehaviour : MonoBehaviour
{
    public EnemyStats stats;
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    [SerializeField] LayerMask playerMask;
    [SerializeField] MyUtilities.EnemyState state;

    [Header("Wwise Events")]
    [Space(20)]
    [SerializeField] AK.Wwise.Event idleOgre;

    [HideInInspector] public UnityEvent imDie;
    bool ifSetPositionPivot;
    Animator enemyAnimator;
    EnemyInteractions enemyInteract;
    float auxTimer;

    private void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyInteract = GetComponent<EnemyInteractions>();

        idleOgre.Post(gameObject);

        if (enemyInteract != null)
        {
            enemyInteract.hasBeenHited.AddListener(SetHitAnimation);
        }
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

    private void OnDisable()
    {
        idleOgre.Stop(gameObject);
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
            idleOgre.Post(gameObject);
            enemyAnimator.SetTrigger("Idle");
        }
        //
        if (Vector2.Distance(transform.position, enemyAttack.playerTransform.position) <= stats.distanceToAttack)
        {
            state = MyUtilities.EnemyState.Attacking;
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
        {
            enemyAttack.SetPivotPosition(enemyAttack.playerTransform.position);
            ifSetPositionPivot = true;
            enemyAnimator.SetTrigger("Attack");
        }
        //auxTimer += Time.deltaTime;
        //if(auxTimer >= stats.attackDelay)
        //{
        //    enemyAnimator.SetTrigger("Attack");
        //}
    }

    void SetHitAnimation()
    {
        enemyMovement.StopMove();
        enemyAnimator.SetTrigger("Damage"); //Ejecuta al final de esta animacion un evento que llama lo de abajo
    }

    public void SetChaseState()
    {
        auxTimer = 0f;
        state = MyUtilities.EnemyState.Chasing;
        enemyAnimator.SetTrigger("Chase");
    }
}
