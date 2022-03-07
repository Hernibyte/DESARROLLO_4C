using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField] DeckOfCardsBehaviour inventory;
    [SerializeField] ListOfCards listOfCards;

    [Header("MIN STATS")]
    [Space(15)]
    [SerializeField] int minMaxHearts;
    [SerializeField] int minDamage;
    [SerializeField] float minSpeedPlayer;
    [SerializeField] float minDefense;
    [Header("MAX STATS")]
    [Space(15)]
    [SerializeField] int capMaxHearts;
    [SerializeField] int capDamage;
    [SerializeField] float capSpeedPlayer;
    [SerializeField] float capDefense;

    [HideInInspector] public PlayerStats playerStats;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GetPlayerStatsReference()
    {
        playerStats = gameManager.playerTransform.GetComponent<PlayerStats>();
    }

    public ListOfCards GetListOfCards()
    {
        return listOfCards;
    }

    public Card GetCardByID(int id)
    {
        return listOfCards.cardList[id];
    }

    public void ModifyStats()
    {
        int extraCardsHP = 0;
        float extraCardsDEF = 0;
        int extraCardsDMG = 0;
        float extraCardsVEL = 0;

        foreach (int id in inventory.idsOfCardsInEquipment)
        {
            if (id != -1)
            {
                //HEALTH POINTS CHGANGE
                extraCardsHP += listOfCards.cardList[id].data.heartsChange;

                //DEFENSE CHGANGE
                extraCardsDEF += listOfCards.cardList[id].data.defenseChange;

                //DAMAGE CHGANGE
                extraCardsDMG += listOfCards.cardList[id].data.damageChange;

                //MOVE SPEED CHGANGE
                extraCardsVEL += listOfCards.cardList[id].data.moveSpeedChange;
            }
            // Modifica todos los valores necesarios del playerstats en relacion a las ids de las cartas
        }

        SetValueStat(ref playerStats.maxHearts, playerStats.initialMaxHearts + extraCardsHP, minMaxHearts, capMaxHearts);
        SetValueStat(ref playerStats.totalDefense, extraCardsDEF, minDefense, capDefense);
        SetValueStat(ref playerStats.totalDamageMelee, playerStats.initialDmgMelee + extraCardsDMG, minDamage, capDamage);
        SetValueStat(ref playerStats.totalDamageRange, playerStats.initialDmgRange + extraCardsDMG, minDamage, capDamage);
        SetValueStat(ref playerStats.totalForceMovement, playerStats.initialForceMovement + extraCardsVEL, minSpeedPlayer, capSpeedPlayer);
    }

    void SetValueStat(ref float stat, float value, float minimumCondition, float maximumCondition)
    {
        if (value > minimumCondition)
        {
            if (value < maximumCondition)
                stat = value;
            else
                stat = maximumCondition;
        }
        else
        {
            stat = minimumCondition;
        }
    }

    void SetValueStat(ref int stat, int value, int minimumCondition, int maximumCondition)
    {
        if (value > minimumCondition)
        {
            if (value < maximumCondition)
                stat = value;
            else
                stat = maximumCondition;
        }
        else
        {
            stat = minimumCondition;
        }
    }
}
