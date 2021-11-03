using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] DeckOfCardsBehaviour inventory;
    [SerializeField] ListOfCards listOfCards;

    [Header("MIN STATS")]
    [Space(15)]
    [SerializeField] float minSpeedPlayer;
    [SerializeField] float minMaxHP;
    [SerializeField] float minDefense;
    [SerializeField] float minDamage;
    [Header("MAX STATS")]
    [Space(15)]
    [SerializeField] float capSpeedPlayer;
    [SerializeField] float capMaxHP;
    [SerializeField] float capDefense;
    [SerializeField] float capDamage;

    [HideInInspector] public PlayerStats playerStats;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetPlayerStatsReference()
    {
        playerStats = gameManager.playerTransform.GetComponent<PlayerStats>();
    }

    public ListOfCards GetListOfCards()
    {
        return listOfCards;
    }

    public Card GetCardByID(int id)
    {
        return listOfCards.cardList[id];
    }

    public void ModifyStats()
    {
        float extraCardsHP = 0;
        float extraCardsDEF = 0;
        float extraCardsDMG = 0;
        float extraCardsVEL = 0;

        foreach(int id in inventory.idsOfCardsInEquipment)
        {
            if(id != -1)
            {
                //HEALTH POINTS CHGANGE
                extraCardsHP += listOfCards.cardList[id].data.lifeChange;

                //DEFENSE CHGANGE
                extraCardsDEF += listOfCards.cardList[id].data.defenseChange;

                //DAMAGE CHGANGE
                extraCardsDMG += listOfCards.cardList[id].data.damageChange;

                //MOVE SPEED CHGANGE
                extraCardsVEL += listOfCards.cardList[id].data.moveSpeedChange;
            }
            // Modifica todos los valores necesarios del playerstats en relacion a las ids de las cartas
        }

        SetValueStat(ref playerStats.totalMaxHP, (playerStats.maxHp + extraCardsHP), minMaxHP, capMaxHP);
        SetValueStat(ref playerStats.totalDefense, (playerStats.defense + extraCardsDEF), minDefense, capDefense);
        SetValueStat(ref playerStats.totalDamageMelee, (playerStats.damageMeleeAttack + extraCardsDMG), minDamage, capDamage);
        SetValueStat(ref playerStats.totalDamageRange, (playerStats.damageRangeAttack + extraCardsDMG), minDamage, capDamage);
        SetValueStat(ref playerStats.totalForceMovement, (playerStats.forceMovement + extraCardsVEL), minSpeedPlayer, capSpeedPlayer);
    }

    void SetValueStat(ref float stat, float value, float minimumCondition, float maximumCondition)
    {
        if (value > minimumCondition)
        {
            if (value < maximumCondition)
                stat = value;
            else
                stat = maximumCondition;
        }
        else
        {
            stat = minimumCondition;
        }
    }
}
