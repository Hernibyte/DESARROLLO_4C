using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] Player player;
    [SerializeField] PlayerStats stats;
    [SerializeField] PlayerMovement movement;
    public MyUtilities.MyUnityEvent2F hasRecivedDamage = new MyUtilities.MyUnityEvent2F();

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        CameraShake.Instance?.ExecuteShake(0.2f, 0.2f);

        stats.lifeAmount -= amountDamage;
        hasRecivedDamage?.Invoke(stats.lifeAmount, stats.totalMaxHP);
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
        player.CheckIfDie(stats.lifeAmount);
    }
}
