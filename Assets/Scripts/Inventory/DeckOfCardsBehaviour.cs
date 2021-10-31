using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckOfCardsBehaviour : MonoBehaviour
{
    public int cardsAmount;
    [HideInInspector] public int[] idsOfCardsInEquipment;

    void Awake()
    {
        idsOfCardsInEquipment = new int[cardsAmount];
        for(int i = 0; i < cardsAmount; i++)
            idsOfCardsInEquipment[i] = new int();
    }

    public void EquipCardByID(int index, int id)
    {
        if(index >= 0 && index <= (cardsAmount-1))
            idsOfCardsInEquipment[index] = id;
    }
}
