using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SlotOfCard : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler
{
    public HoverDescription hoverDescription;
    public TextMeshProUGUI textSlot;
    public int idCardTaked;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void SetIdCardTaked(int id)
    {
        idCardTaked = id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverDescription == null)
            return;

        hoverDescription.ShowHoverDescription();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverDescription == null)
            return;

        hoverDescription.HideHoverDescription();
    }
}
