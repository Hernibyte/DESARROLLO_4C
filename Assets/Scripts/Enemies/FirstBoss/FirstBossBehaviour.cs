using UnityEngine;
using UnityEngine.Events;

public class FirstBossBehaviour : MonoBehaviour
{
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    [SerializeField] LayerMask playerMask;
    [SerializeField] MyUtilities.EnemyState state;
    [HideInInspector] public UnityEvent imDie;
    bool ifSetPositionPivot;
    //float auxTimer;

    Animator animBoss;

    void Start()
    {
        animBoss = gameObject.GetComponentInChildren<Animator>();
        enemyMovement.enemySprite.enabled = false;
    }

    void Update()
    {
        if (!animBoss.GetBool("Spawned"))
            return;

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
        }
    }

    void Chasing()
    {
        if(Vector2.Distance(transform.position, enemyAttack.playerTransform.position) >= stats.distanceTracking)
        {
            state = MyUtilities.EnemyState.Idle;
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
            animBoss.SetTrigger("Attack");
        }
        //auxTimer += Time.deltaTime;
        //if(auxTimer >= stats.attackDelay)
        //{
        //    //enemyAttack.MeleeAttack(playerMask);
        //    state = MyUtilities.EnemyState.Chasing;
        //    auxTimer = 0f;
        //}
    }

    public void SetChaseState()
    {
        Debug.Log("Cambio state chase boss");
        state = MyUtilities.EnemyState.Chasing;
        animBoss.ResetTrigger("Attack");
        //auxTimer = 0f;
    }
}
