using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverDescription : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameCard;
    [SerializeField] TextMeshProUGUI lifeSpec;
    [SerializeField] TextMeshProUGUI defenseSpec;
    [SerializeField] TextMeshProUGUI damageSpec;
    [SerializeField] TextMeshProUGUI moveSpeedSpec;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowHoverDescription()
    {
        if (animator == null)
            return;

        animator.SetBool("HoverIsOpen", true);
    }

    public void HideHoverDescription()
    {
        if (animator == null)
            return;

        animator.SetBool("HoverIsOpen", false);
    }

    public void HoverDescriptionWhitoutCard()
    {
        nameCard.text = "NO CARD";
        CheckAndShowSpec(0, lifeSpec, "", "");
        CheckAndShowSpec(0, defenseSpec, "", "");
        CheckAndShowSpec(0, damageSpec, "", "");
        CheckAndShowSpec(0, moveSpeedSpec, "","");
    }

    public void UpdateDataCardDescription(Card cardData)
    {
        if (cardData == null)
            return;

        nameCard.text = cardData.data.name;

        CheckAndShowSpec(cardData.data.heartsChange, lifeSpec, "HP +", "HP ");
        CheckAndShowSpec(cardData.data.defenseChange, defenseSpec, "DEF +", "DEF ");
        CheckAndShowSpec(cardData.data.damageChange, damageSpec, "DMG +", "DMG ");
        CheckAndShowSpec(cardData.data.moveSpeedChange, moveSpeedSpec, "VEL +", "VEL ");
    }

    void CheckAndShowSpec(float spec, TextMeshProUGUI textSpecOnHover, string positiveSpec, string negativeSpec)
    {
        if (spec != 0 && !textSpecOnHover.gameObject.activeSelf)
            textSpecOnHover.gameObject.SetActive(true);

        if (spec == 0)
        {
            textSpecOnHover.gameObject.SetActive(false);
            return;
        }

        if (spec > 0)
        {
            textSpecOnHover.color = Color.green;
            textSpecOnHover.text = positiveSpec + spec.ToString();
        }
        else if(spec < 0)
        {
            textSpecOnHover.color = Color.red;
            textSpecOnHover.text = negativeSpec + spec.ToString();
        }
    }
}
