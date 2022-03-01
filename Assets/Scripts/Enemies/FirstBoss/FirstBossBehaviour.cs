using UnityEngine;
using UnityEngine.Events;

public class FirstBossBehaviour : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    [SerializeField] LayerMask playerMask;
    [SerializeField] MyUtilities.EnemyState state;
    [SerializeField,Range(0, 100)] private float porcentageAttackZone = 0;
    [HideInInspector] public UnityEvent imDie;
    #endregion

    #region PRIVATE_FIELDS
    bool ifSetPositionPivot;
    private Animator animBoss;
    private float randomChange = 0;
    private float initialSpeed = 0;
    private bool trackingPlayerOnAir = false;
    #endregion

    void Start()
    {
        animBoss = gameObject.GetComponentInChildren<Animator>();
        enemyMovement.enemySprite.enabled = false;

        initialSpeed = stats.movementForce;
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
            randomChange = Random.Range(0, 100);

            if (randomChange < porcentageAttackZone)
            {
                animBoss.SetTrigger("AttackZone");
                trackingPlayerOnAir = true;
            }
            else
            {
                animBoss.SetTrigger("Attack");
            }

            enemyAttack.SetPivotPosition(enemyAttack.playerTransform.position);
            ifSetPositionPivot = true;
        }

        if (randomChange < porcentageAttackZone && trackingPlayerOnAir)
        {
            stats.movementForce = initialSpeed * 2;
            enemyMovement.Move(enemyAttack.playerTransform.position);
            enemyMovement.DisableCollision();
        }
        //auxTimer += Time.deltaTime;
        //if(auxTimer >= stats.attackDelay)
        //{
        //    //enemyAttack.MeleeAttack(playerMask);
        //    state = MyUtilities.EnemyState.Chasing;
        //    auxTimer = 0f;
        //}
    }

    public void StopTrackPlayerOnAir()
    {
        trackingPlayerOnAir = false;
    }

    public void SetChaseState()
    {
        Debug.Log("Cambio state chase boss");
        state = MyUtilities.EnemyState.Chasing;
        stats.movementForce = initialSpeed;
        enemyMovement.EnableCollision();
        /*animBoss.ResetTrigger("Attack");
        animBoss.ResetTrigger("AttackZone");*/
        //auxTimer = 0f;
    }
}
