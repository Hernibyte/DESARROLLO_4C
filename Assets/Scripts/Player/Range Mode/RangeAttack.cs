using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [Header("ATTACK NEEDS")]
    [SerializeField] ProjectileBehaviour projectilePrefab;
    public Transform firePoint;
    [SerializeField] Rigidbody2D firePointRb;
    
    [Header("ATTACK SETTINGS")]
    [Space(10)]
    [SerializeField] float delayAttack;
    [SerializeField] float tToRestore;

    PlayerStats playerData;
    Vector2 mousePosition;


    void Start()
    {
        tToRestore = 0;
        playerData = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        firePointRb.position = transform.position;

        if (tToRestore < delayAttack)
            tToRestore += Time.deltaTime;
        else
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                ShootProjectile();
            }
        }

    }

    void FixedUpdate()
    {
        Vector2 directionShoot = mousePosition - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(directionShoot.y,directionShoot.x) * Mathf.Rad2Deg - 90f;
        firePointRb.rotation = angle;
    }

    public void ShootProjectile()
    {
        tToRestore = 0;
        ProjectileBehaviour projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        if (projectile != null)
            projectile.SetValuesAndShoot(playerData.damageRangeAttack, playerData.knockbackRange, firePoint);
    }
}
