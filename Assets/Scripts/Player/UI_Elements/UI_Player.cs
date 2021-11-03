using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI porcentHP;
    [SerializeField] Image fillHP; 
    [SerializeField] Image fillDamageEntry;
    [SerializeField] Animator panelScreen;
    [SerializeField] StatsOnPanel allStats;

    [HideInInspector] public StatsManager statsMng;

    bool needUpdateHelathBar;
    float targetFillAmount;

    private void Start()
    {
        statsMng = FindObjectOfType<StatsManager>();
    }
    private void Update()
    {
        if(needUpdateHelathBar)
        {
            UpdateFillDamageEntry();
        }
    }

    public void StartStatsPanel()
    {
        float hp = statsMng.playerStats.maxHp;
        float def = statsMng.playerStats.defense;
        float dmg = statsMng.playerStats.damageMeleeAttack + statsMng.playerStats.damageRangeAttack;
        float vel = statsMng.playerStats.forceMovement;

        allStats.StartDefaulPanelStats(hp,def,dmg,vel);
    }

    public void UpdateStatsAfterCheat()
    {
        allStats.UpdateStat(statsMng.playerStats.totalMaxHP, 0, statsMng.playerStats.totalDefense, 0,
            statsMng.playerStats.totalDamageMelee+ statsMng.playerStats.totalDamageRange, 0,
            statsMng.playerStats.totalForceMovement, 0);
    }

    public void UpdateStatsPanel(DeckOfCardsBehaviour allCardsInDeck, ListOfCards allCards)
    {
        float basicHp = statsMng.playerStats.maxHp;
        float basicDef = statsMng.playerStats.defense;
        float basicDmg = statsMng.playerStats.damageMeleeAttack + statsMng.playerStats.damageRangeAttack;
        float basicVel = statsMng.playerStats.forceMovement;
        float extraHp = 0;
        float extraDef = 0;
        float extraDmg = 0;
        float extraVel = 0;

        foreach (int id in allCardsInDeck.idsOfCardsInEquipment)
        {
            if(id != -1)
            {
                extraHp += allCards.cardList[id].data.lifeChange;

                extraDef += allCards.cardList[id].data.defenseChange;

                extraDmg += allCards.cardList[id].data.damageChange;

                extraVel += allCards.cardList[id].data.moveSpeedChange;
            }
        }

        allStats.UpdateStat(basicHp,extraHp,basicDef,extraDef,basicDmg,extraDmg,basicVel,extraVel);
    }

    public void UpdateUIPlayer(float updateHealthPoints, float maxHelathPointsPlayer)
    {
        float porcentActualHP = (updateHealthPoints * 100) / maxHelathPointsPlayer;
        porcentHP.text = porcentActualHP.ToString("0") + "%";

        UpdateFillHP(updateHealthPoints, maxHelathPointsPlayer);
    }

    void UpdateFillHP(float updateHealthPoints, float maxHelathPointsPlayer)
    {
        float damageToHP = updateHealthPoints / maxHelathPointsPlayer;
        fillHP.fillAmount = damageToHP;

        targetFillAmount = damageToHP;
        StartCoroutine(WaitToApplyDamage());
    }

    IEnumerator WaitToApplyDamage()
    {
        yield return new WaitForSeconds(0.15f);

        needUpdateHelathBar = true;
    }

    void UpdateFillDamageEntry()
    {
        if(fillDamageEntry.fillAmount > targetFillAmount)
        {
            fillDamageEntry.fillAmount -= Time.deltaTime / 4;
        }
        else
        {
            fillDamageEntry.fillAmount = targetFillAmount;
            needUpdateHelathBar = false;
        }
    }

    public void OpenAndClosePanelPlayer()
    {
        panelScreen.SetBool("PanelIsOpen", !panelScreen.GetBool("PanelIsOpen"));
    }
}