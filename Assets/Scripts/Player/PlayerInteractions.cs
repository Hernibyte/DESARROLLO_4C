using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] Player player;
    [SerializeField] PlayerStats stats;
    [SerializeField] PlayerMovement movement;
    public MyUtilities.MyUnityEvent2I hasRecivedDamage = new MyUtilities.MyUnityEvent2I();

    public void ReciveHit(int amountHeartsDmg, float knockBackForce, Vector2 posAttacker)
    {
        CameraShake.Instance?.ExecuteShake(0.2f, 0.2f);

        stats.heartsAmount -= amountHeartsDmg;

        hasRecivedDamage?.Invoke(stats.heartsAmount, stats.maxHearts);
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
        player.CheckIfDie(stats.heartsAmount);
    }
}
