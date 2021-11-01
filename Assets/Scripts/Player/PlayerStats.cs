using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("BASIC MOVEMENT STATS")]
    public float forceMovement;
    public float dodgeForce;
    public float dodgeDistance;
    [Header("(BASIC + EXTRA CARDS) MOVEMENT STATS")]
    [Space(15)]
    public float totalForceMovement;

    [Header("BASIC STATS")]
    [Space(15)]
    public float maxHp;
    public float lifeAmount;
    public float defense;
    public float damageReducedByDef;
    [Header("(BASIC + EXTRA CARDS) STATS")]
    [Space(15)]
    public float totalMaxHP;
    public float totalDefense;

    [Header("BASIC ATTACK STATS")]
    [Space(15)]
    public int damageRangeAttack;
    public int damageMeleeAttack;
    public float knockbackRange;
    public float knockbackMelee;
    [Header("(BASIC + EXTRA CARDS) ATTACK STATS")]
    [Space(15)]
    public float totalDamageMelee;
    public float totalDamageRange;

    private void Start()
    {
        lifeAmount = maxHp; //Inicialmente asi, desp cuando se consigan cartas si se cura lo haria con el TotalMaxHP
        totalMaxHP = maxHp;
        totalDefense = defense;
        totalForceMovement = forceMovement;
        totalDamageMelee = damageMeleeAttack;
        totalDamageRange = damageRangeAttack;
    }
}
