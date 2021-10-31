using UnityEngine;

public class LootTakedPanel : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LootManager lootReference;

    private void OnEnable()
    {
        lootReference.lootTaken += ShowLootPanel;
    }

    private void OnDisable()
    {
        lootReference.lootTaken -= ShowLootPanel;
    }

    public void ShowLootPanel()
    {
        animator.SetBool("ShowLootPanel", true);
    }

    public void HideLootPanel()
    {
        animator.SetBool("ShowLootPanel", false);
    }
}
