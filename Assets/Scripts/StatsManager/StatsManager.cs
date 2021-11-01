using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] DeckOfCardsBehaviour inventory;
    [SerializeField] ListOfCards listOfCards;
    public PlayerStats playerStats;
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

        playerStats.totalMaxHP = playerStats.maxHp + extraCardsHP;
        playerStats.totalDefense = playerStats.defense + extraCardsDEF;
        playerStats.totalDamageMelee = playerStats.damageMeleeAttack + extraCardsDMG;
        playerStats.totalDamageRange = playerStats.damageRangeAttack + extraCardsDMG;
        playerStats.totalForceMovement = playerStats.forceMovement + extraCardsVEL;
    }
}
