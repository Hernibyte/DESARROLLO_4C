using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] DeckOfCardsBehaviour inventory;
    [SerializeField] ListOfCards listOfCards;
    [SerializeField] PlayerStats playerStats;

    public void ModifyStats()
    {
        foreach(int id in inventory.idsOfCardsInEquipment)
        {
            Debug.Log(listOfCards.cardList[id].data.name);
            // Modifica todos los valores necesarios del playerstats en relacion a las ids de las cartas
        }
    }
}
