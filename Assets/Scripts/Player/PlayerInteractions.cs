using UnityEngine;
using UnityEngine.Events;

public class MyUnityEvent : UnityEvent<float,float>
{
}

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    [SerializeField] PlayerStats stats;
    [SerializeField] PlayerMovement movement;
    public MyUnityEvent hasRecivedDamage = new MyUnityEvent();

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        stats.lifeAmount -= amountDamage;
        hasRecivedDamage?.Invoke(stats.lifeAmount, stats.maxHp);
        Vector2 difference = new Vector2(transform.position.x, transform.position.y) - posAttacker;
        movement.ImpulseAttack(difference, knockBackForce);
    }
}
