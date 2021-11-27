using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    [SerializeField] Vector2 ramdomRange;
    [SerializeField] GameObject lootPrefab;

    public void GenerateLoot(Vector2 position)
    {
        if(Random.Range((int)ramdomRange.x, (int)ramdomRange.y + 1) == ramdomRange.x)
        {
            AkSoundEngine.PostEvent("aparece_loot", gameObject);

            Instantiate(lootPrefab, position, Quaternion.identity, transform);
        }
    }
}