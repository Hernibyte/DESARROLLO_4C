using UnityEngine;

public class LootRef : MonoBehaviour
{
    Loot referenceToLoot;
    private void Start()
    {
        referenceToLoot = GetComponentInParent<Loot>();
    }

    public void GiveLootAndDestroy()
    {
        if (referenceToLoot == null)
            return;

        referenceToLoot.GiveLootAndDestroy();
    }
}