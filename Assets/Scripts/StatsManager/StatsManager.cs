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

    public Card GetCardByID(int id)
    {
        return listOfCards.cardList[id];
    }

    public void ModifyStats()
    {
        foreach(int id in inventory.idsOfCardsInEquipment)
        {
            Debug.Log(listOfCards.cardList[id].data.name);
            // Modifica todos los valores necesarios del playerstats en relacion a las ids de las cartas
        }
    }
}
