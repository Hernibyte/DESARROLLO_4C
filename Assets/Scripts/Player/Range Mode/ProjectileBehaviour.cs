using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask layerToAttack;
    [SerializeField] LayerMask roomLayer;
    [SerializeField] Rigidbody2D rb;

    int damageProjectile;
    float knockBack;

    public void SetValuesAndShoot(int damageDelt, float knockBackForce, Transform direction)
    {
        damageProjectile = damageDelt;
        knockBack = knockBackForce;
        ShootDirection(direction);
    }

    void ShootDirection(Transform direction)
    {
        rb.AddForce(direction.up * speed, ForceMode2D.Impulse);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        HitSomething(collision);
    }

    public void HitSomething(Collider2D collision)
    {
        if (MyUtilities.Contains(layerToAttack, collision.gameObject.layer))
        {
            IReciveDamage impactDone = collision.GetComponent<IReciveDamage>();
            if (impactDone != null)
            {
                impactDone.Damage(damageProjectile, knockBack, transform.position);
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GoOutRoom(collision);
    }

    public void GoOutRoom(Collider2D collision)
    {
        if (MyUtilities.Contains(roomLayer, collision.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
