using UnityEngine;
using TMPro;

public class LootTakedPanel : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LootManager lootReference;
    [SerializeField] TextMeshProUGUI nameCard;

    private void OnEnable()
    {
        lootReference.lootTaken += ShowLootPanel;
    }

    private void OnDisable()
    {
        lootReference.lootTaken -= ShowLootPanel;
    }

    public void SetCardNameToUI()
    {
        if (lootReference == null || lootReference.GetCardsAviable().cardList.Count <= 0)
            return;

        nameCard.text = lootReference.GetCardsAviable().cardList[lootReference.GetLastCardTaked()].data.name;
    }

    public void ShowLootPanel()
    {
        SetCardNameToUI();
        animator.SetBool("ShowLootPanel", true);
    }

    public void HideLootPanel()
    {
        animator.SetBool("ShowLootPanel", false);
    }
}
