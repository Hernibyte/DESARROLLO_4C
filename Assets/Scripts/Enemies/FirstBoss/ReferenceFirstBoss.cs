using UnityEngine;

public class ReferenceFirstBoss : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    EnemyStats enemyStats;

    FirstBossBehaviour enemy;
    CameraShake camReference;

    float radiusAttackOriginal;
    float radiusAttackBoosted;

    void Start()
    {
        camReference = FindObjectOfType<CameraShake>();

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
        enemy.enemyAttack.MeleeAttack(playerLayer);
    }

    public void MeleeAttackBoosted()
    {
        BoostRadiusZone();
        enemy.enemyAttack.MeleeAttack(playerLayer);
    }

    public void StartChaseAgain()
    {
        ResetRadiusZone();
        enemy.SetChaseState();
    }

    public void MakeScreenShake()
    {
        camReference.Shake(1f, 1f);
    }

    public void ZoneAttack()
    {
        //Hay que hacerlo
    }
}
