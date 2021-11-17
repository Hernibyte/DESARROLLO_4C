using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Loot : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Light2D point2D;
    Animator animController;
    LootManager lootManager;

    private void Start()
    {
        animController = GetComponentInChildren<Animator>();
        point2D.gameObject.SetActive(false);
        lootManager = FindObjectOfType<LootManager>();
    }

    public void GiveLootAndDestroy()
    {
        point2D.gameObject.SetActive(true);
        int randomCard = Random.Range(0, lootManager.GetCardsAviable().cardList.Count);
        lootManager.SetLasCardTaked(randomCard);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(MyUtilities.Contains(playerLayer, collision.gameObject.layer))
        {
            if(Input.GetKey(KeyCode.E))
            {
                AkSoundEngine.PostEvent("open_loot", gameObject);
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        animController.SetTrigger("Open");
    }
}
