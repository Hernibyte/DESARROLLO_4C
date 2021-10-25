using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    Animator animator;
    Camera mainCamera;
    public UnityEvent updateSpriteDirection;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        mainCamera = FindObjectOfType<Camera>();
        tToRestore = 0;
        playerData = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        firePointRb.position = new Vector2(transform.position.x, transform.position.y) + Vector2.up;

        if (tToRestore < delayAttack)
            tToRestore += Time.deltaTime;
        else
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("RangeAttack");
                ShootProjectile();
            }
        }

        updateSpriteDirection?.Invoke();
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
