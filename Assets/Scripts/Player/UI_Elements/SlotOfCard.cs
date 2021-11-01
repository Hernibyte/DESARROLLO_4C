using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SlotOfCard : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler
{
    public HoverDescription hoverDescription;
    public DeckOfCardsBehaviour inventoryPlayer;
    public TextMeshProUGUI textSlot;
    public int idCardTaked;

    StatsManager stats;
    LootManager loot;
    UI_Player uiPlayer;

    void Start()
    {
        idCardTaked = -1;
        uiPlayer = GetComponentInParent<UI_Player>();
        stats = FindObjectOfType<StatsManager>();
        loot = FindObjectOfType<LootManager>();
    }

    public void SetIdCardTaked(int id)
    {
        idCardTaked = id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (loot == null)
            return;

        if(loot.GetLastCardTaked() != - 1)
        {
            idCardTaked = loot.GetLastCardTaked();
            inventoryPlayer.EquipCardByID(idCardTaked, idCardTaked);

            stats.ModifyStats();
            loot.DiscardIndexCardTaked();
            uiPlayer.UpdateStatsPanel(inventoryPlayer, stats.GetListOfCards() );

            hoverDescription.UpdateDataCardDescription( stats.GetCardByID(idCardTaked) );
            textSlot.text = stats.GetCardByID(idCardTaked).data.name;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverDescription == null)
            return;

        hoverDescription.ShowHoverDescription();
        if (idCardTaked != -1)
            hoverDescription.UpdateDataCardDescription(stats.GetCardByID(idCardTaked));
        else
            hoverDescription.HoverDescriptionWhitoutCard();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverDescription == null)
            return;

        hoverDescription.HideHoverDescription();
    }
}
