using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] Player player;
    [SerializeField] PlayerStats stats;
    [SerializeField] PlayerMovement movement;
    public MyUtilities.MyUnityEvent hasRecivedDamage = new MyUtilities.MyUnityEvent();

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        stats.lifeAmount -= amountDamage;
        hasRecivedDamage?.Invoke(stats.lifeAmount, stats.maxHp);
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
        player.CheckIfDie(stats.lifeAmount);
    }
}
