using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    LootManager lootManager;

    private void Start()
    {
        lootManager = FindObjectOfType<LootManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(MyUtilities.Contains(playerLayer, collision.gameObject.layer))
        {
            if(Input.GetKey(KeyCode.E))
            {
                int randomCard = Random.Range(0, lootManager.GetCardsAviable().cardList.Count);
                lootManager.SetLasCardTaked(randomCard);
                
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
