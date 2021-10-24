using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IHitabble
{
    SpriteRenderer playerSprite;
    RangeAttack rangeSystem;

    private void Start()
    {
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        rangeSystem = GetComponentInChildren<RangeAttack>();
    }
    private void Update()
    {
        ChangeSideSprite();
    }

    public void ReciveDamage(float amountDamage, float knockBackForce, Vector2 posAttacker)
    {
        //Daño
        Debug.Log("Hola");
    }

    void ChangeSideSprite()
    {
        if (rangeSystem.firePoint.up.x > 0)
            playerSprite.flipX = false;
        else
            playerSprite.flipX = true;
    }
}
