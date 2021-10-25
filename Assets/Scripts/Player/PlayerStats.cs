using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("MOVEMENT STATS")]
    public float forceMovement;
    public float dodgeForce;
    public float dodgeDistance;

    [Header("BASIC STATS")]
    [Space(15)]
    public float maxHp;
    public float lifeAmount;
    public float defense;
    public float damageReducedByDef;

    [Header("ATTACK STATS")]
    [Space(15)]
    public int damageRangeAttack;
    public int damageMeleeAttack;
    public float knockbackRange;
    public float knockbackMelee;

    private void Start()
    {
        lifeAmount = maxHp;
    }
}
