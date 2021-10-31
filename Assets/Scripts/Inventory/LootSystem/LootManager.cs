using UnityEngine;
using UnityEngine.Events;

public class LootManager : MonoBehaviour
{
    [SerializeField] ListOfCards cardsAviable;
    [SerializeField] int indexLastCardTaked;

    public UnityAction lootTaken;

    private void Start()
    {
        indexLastCardTaked = -1;
        cardsAviable = FindObjectOfType<ListOfCards>();
    }

    public void DiscardIndexCardTaked()
    {
        indexLastCardTaked = -1;
    }

    public void SetLasCardTaked(int index)
    {
        indexLastCardTaked = index;
        lootTaken?.Invoke();
    }

    public int GetLastCardTaked()
    {
        return indexLastCardTaked;
    }

    public ListOfCards GetCardsAviable()
    {
        return cardsAviable;
    }
}
