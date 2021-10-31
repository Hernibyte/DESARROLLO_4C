using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootGenerator : MonoBehaviour
{
    [SerializeField] Vector2 ramdomRange;
    [SerializeField] GameObject lootPrefab;

    public void GenerateLoot(Vector2 position)
    {
        if(Random.Range(ramdomRange.x, ramdomRange.y + 1) == ramdomRange.x)
        {
            Instantiate(lootPrefab, position, Quaternion.identity, transform);
        }
    }
}
