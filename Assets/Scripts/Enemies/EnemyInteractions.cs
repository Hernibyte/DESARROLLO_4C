using UnityEngine;

public class EnemyInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] EnemyStats stats;
    [SerializeField] EnemyMovement movement;
    [SerializeField] Enemy enemy;
    public MyUtilities.MyUnityEvent2F hasRecivedDamage = new MyUtilities.MyUnityEvent2F();
    public MyUtilities.MyUnityEventNoParam hasBeenHited = new MyUtilities.MyUnityEventNoParam();

    /*public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        CameraShake.Instance?.ExecuteShake(0.2f, 0.2f);

        stats.distanceTracking = 80;

        //stats.heartsAmount -= amountDamage;
        hasRecivedDamage?.Invoke(stats.heartsAmount, stats.maxHearts);
        hasBeenHited?.Invoke();

        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
        enemy.CheckIfDie(stats.heartsAmount);
    }*/

    public void ReciveHit(int amountHeartsDmg, float knockBack, Vector2 posAttacker)
    {
        CameraShake.Instance?.ExecuteShake(0.2f, 0.2f);

        stats.distanceTracking = 80;

        stats.heartsAmount -= amountHeartsDmg;
        hasRecivedDamage?.Invoke(stats.heartsAmount, stats.maxHearts);
        hasBeenHited?.Invoke();

        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBack);
        enemy.CheckIfDie(stats.heartsAmount);
    }
}
