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
    public float initialForceMovement;

    [Header("BASIC STATS")]
    [Space(15)]
    public int maxHearts;
    public int initialMaxHearts;
    public int heartsAmount;
    public float defense;
    public float damageReducedByDef;
    [Header("(BASIC + EXTRA CARDS) STATS")]
    [Space(15)]
    public int maxHeartsTotal;
    public float totalDefense;

    [Header("BASIC ATTACK STATS")]
    [Space(15)]
    public int damageRangeAttack;
    public int damageMeleeAttack;
    public float knockbackRange;
    public float knockbackMelee;
    [Header("(BASIC + EXTRA CARDS) ATTACK STATS")]
    [Space(15)]
    public int totalDamageMelee;
    public int initialDmgMelee;
    public int totalDamageRange;
    public int initialDmgRange;

    private void Start()
    {
        heartsAmount = maxHearts; //Inicialmente asi, desp cuando se consigan cartas si se cura lo haria con el TotalMaxHP
        initialMaxHearts = maxHearts;

        totalDefense = defense;
        totalForceMovement = forceMovement;
        initialForceMovement = forceMovement;

        initialDmgMelee = damageMeleeAttack;
        initialDmgRange = damageRangeAttack;
        totalDamageMelee = damageMeleeAttack;
        totalDamageRange = damageRangeAttack;
    }
}
