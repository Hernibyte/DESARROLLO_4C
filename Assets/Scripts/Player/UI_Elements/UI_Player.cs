using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Player : MonoBehaviour
{
    [SerializeField] private GameObject prefabHeart = null;
    [SerializeField] private GameObject prefabHeartHolder = null;
    [SerializeField] private Transform holderHearts = null;
    [SerializeField] private Transform holderLosedHearts = null;

    [SerializeField] TextMeshProUGUI porcentHP;
    [SerializeField] StatsOnPanel allStats;

    [HideInInspector] public StatsManager statsMng;
    public Animator panelScreen;

    public MyUtilities.MyUnityEventNoParam OnPanelChangeState = new MyUtilities.MyUnityEventNoParam();

    #region PRIVATE_FIELDS
    private List<Animator> hearts = null;
    private List<Animator> losedHearts = null;
    private bool needUpdateHelathBar;
    private float targetFillAmount;
    #endregion

    private void Start()
    {
        statsMng = FindObjectOfType<StatsManager>();

        hearts = new List<Animator>();
        losedHearts = new List<Animator>();
    }

    public void StartStatsPanel()
    {
        float hp = statsMng.playerStats.heartsAmount;
        float def = statsMng.playerStats.defense;
        float dmg = statsMng.playerStats.damageMeleeAttack + statsMng.playerStats.damageRangeAttack;
        float vel = statsMng.playerStats.forceMovement;

        allStats.StartDefaulPanelStats(hp,def,dmg,vel);
    }

    public void UpdateStatsAfterCheat()
    {
        allStats.UpdateStat(statsMng.playerStats.maxHearts, 0, statsMng.playerStats.totalDefense, 0,
            statsMng.playerStats.totalDamageMelee+ statsMng.playerStats.totalDamageRange, 0,
            statsMng.playerStats.totalForceMovement, 0);

        UpdateUIPlayer(statsMng.playerStats.heartsAmount, statsMng.playerStats.maxHearts);
    }

    public void UpdateStatsPanel(DeckOfCardsBehaviour allCardsInDeck, ListOfCards allCards)
    {
        int basicHp = statsMng.playerStats.maxHearts;
        float basicDef = statsMng.playerStats.defense;
        float basicDmg = statsMng.playerStats.damageMeleeAttack + statsMng.playerStats.damageRangeAttack;
        float basicVel = statsMng.playerStats.forceMovement;
        int extraHp = 0;
        float extraDef = 0;
        float extraDmg = 0;
        float extraVel = 0;

        foreach (int id in allCardsInDeck.idsOfCardsInEquipment)
        {
            if(id != -1)
            {
                extraHp += allCards.cardList[id].data.heartsChange;

                extraDef += allCards.cardList[id].data.defenseChange;

                extraDmg += allCards.cardList[id].data.damageChange;

                extraVel += allCards.cardList[id].data.moveSpeedChange;
            }
        }

        allStats.UpdateStat(basicHp,extraHp,basicDef,extraDef,basicDmg,extraDmg,basicVel,extraVel);
    }

    public void UpdateUIPlayer(int updateHearts, int maxHearts)
    {
        UpdateHeartsPlayer(updateHearts, maxHearts);
    }

    void UpdateHeartsPlayer(int heartsAmount, int maxHearts)
    {
        HandleLifeHearts(hearts, heartsAmount, maxHearts, prefabHeart, holderHearts);

        HandleHolderHearts(losedHearts, maxHearts, prefabHeartHolder, holderLosedHearts);
    }

    private void HandleLifeHearts(List<Animator> hearts, int updatedValue,int maxValue, GameObject prefab, Transform holder)
    {
        int amountHearts = updatedValue - hearts.Count;

        if(amountHearts > 0 && hearts.Count < maxValue)
        {
            for (int i = 0; i < amountHearts; i++)
            {
                GameObject heartCreated = Instantiate(prefab, holder);

                if (heartCreated.TryGetComponent(out Animator heartAnimator))
                {
                    hearts.Add(heartAnimator);
                }
            }
        }
        else
        {
            if (amountHearts >= 0)
            {
                if (statsMng.playerStats.heartsAmount > maxValue)
                {
                    for (int j = hearts.Count - 1; j >= maxValue; j--)
                    {
                        if (j < 0)
                            break;

                        if (hearts[j] != null)
                        {
                            hearts[j].SetTrigger("Hit");
                        }

                        if (hearts.Count > 1)
                        {
                            hearts.RemoveAt(j);
                        }
                    }
                }
                return;
            }

            for (int j = hearts.Count - 1; j >= updatedValue; j--)
            {
                if (j < 0)
                    break;

                if (hearts[j] != null)
                {
                    hearts[j].SetTrigger("Hit");
                }

                if (hearts.Count > 1)
                {
                    hearts.RemoveAt(j);
                }
            }
        }
    }

    private void HandleHolderHearts(List<Animator> hearts, int updatedValue, GameObject prefab, Transform holder)
    {
        int diffValue = updatedValue - hearts.Count;

        if (diffValue == 0)
            return;

        if (diffValue > 0)
        {
            for (int i = 0; i < diffValue; i++)
            {
                GameObject heart = Instantiate(prefab, holder);
                if(heart.TryGetComponent(out Animator heartAnimator))
                {
                    hearts.Add(heartAnimator);
                }
            }
        }
        else
        {
            for (int j = hearts.Count - 1; j >= updatedValue; j--)
            {
                if (j < 0)
                    break;

                if (hearts[j] != null)
                {
                    hearts[j].SetTrigger("Hit");
                }

                if (hearts.Count > 1)
                {
                    hearts.RemoveAt(j);
                }
            }
        }
    }

    public void OpenAndClosePanelPlayer()
    {
        panelScreen.SetBool("PanelIsOpen", !panelScreen.GetBool("PanelIsOpen"));
        OnPanelChangeState?.Invoke();
    }
}