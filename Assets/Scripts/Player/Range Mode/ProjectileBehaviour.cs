using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask layerToAttack;
    [SerializeField] LayerMask roomLayer;
    [SerializeField] Rigidbody2D rb;

    int damageProjectile;
    float knockBack;

    public void SetValuesAndShoot(int damageDelt, float knockBackForce, Transform upFirePoint, Vector2 targetPosition)
    {
        damageProjectile = damageDelt;
        knockBack = knockBackForce;
        Vector2 posUpPoint = upFirePoint.position;
        ShootDirection(upFirePoint, targetPosition - posUpPoint);
    }
    public void FixRotation(Vector2 fireDirection)
    {
        Vector2 directionShoot = fireDirection;
        float angle = Mathf.Atan2(directionShoot.y, directionShoot.x) * Mathf.Rad2Deg;// - 90f;
        rb.rotation = angle;
    }
    void ShootDirection(Transform upFirePoint, Vector2 direction)
    {
        rb.AddForce(upFirePoint.up * speed, ForceMode2D.Impulse);
        FixRotation(direction);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        HitSomething(collision);
    }

    public void HitSomething(Collider2D collision)
    {
        if (MyUtilities.Contains(layerToAttack, collision.gameObject.layer))
        {
            IHitabble impactDone = collision.GetComponent<IHitabble>();
            if (impactDone != null)
            {
                impactDone.ReciveHit(damageProjectile, knockBack, transform.position);
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
