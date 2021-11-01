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
        foreach(int id in inventory.idsOfCardsInEquipment)
        {
            if(id != -1)
            {
                //HEALTH POINTS CHGANGE
                playerStats.totalMaxHP = playerStats.maxHp + listOfCards.cardList[id].data.lifeChange;
                
                //DEFENSE CHGANGE
                playerStats.totalDefense = playerStats.defense + listOfCards.cardList[id].data.defenseChange;

                //DAMAGE CHGANGE
                playerStats.totalDamageMelee = playerStats.damageMeleeAttack + listOfCards.cardList[id].data.damageChange;
                playerStats.totalDamageRange = playerStats.damageRangeAttack + listOfCards.cardList[id].data.damageChange;

                //MOVE SPEED CHGANGE
                playerStats.totalForceMovement = playerStats.forceMovement + listOfCards.cardList[id].data.moveSpeedChange;
            }
            // Modifica todos los valores necesarios del playerstats en relacion a las ids de las cartas
        }
    }
}
