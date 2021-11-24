using UnityEngine;

public class ReferenceFirstBoss : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    EnemyStats enemyStats;

    FirstBossBehaviour enemy;
    float radiusAttackOriginal;
    float radiusAttackBoosted;

    void Start()
    {
        enemy = GetComponentInParent<FirstBossBehaviour>();
        enemyStats = GetComponentInParent<EnemyStats>();

        radiusAttackOriginal = enemyStats.attackRadiusArea;
        radiusAttackBoosted = enemyStats.attackRadiusArea + 2;
    }

    void ResetRadiusZone()
    {
        enemyStats.attackRadiusArea = radiusAttackOriginal;
    }

    void BoostRadiusZone()
    {
        enemyStats.attackRadiusArea = radiusAttackBoosted;
    }

    public void MeleeAttack()
    {
        CameraShake.Instance?.ExecuteShake(.2f, .1f);
        enemy.enemyAttack.MeleeAttack(playerLayer);
    }

    public void MeleeAttackBoosted()
    {
        BoostRadiusZone();
        CameraShake.Instance.ExecuteShake(.2f, .4f);
        enemy.enemyAttack.MeleeAttack(playerLayer);
    }

    public void StartChaseAgain()
    {
        ResetRadiusZone();
        enemy.SetChaseState();
    }

    public void MakeScreenShake()
    {
        CameraShake.Instance.ExecuteShake(1f, 1f);
    }

    public void ZoneAttack()
    {
        //Hay que hacerlo
    }
}
