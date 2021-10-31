using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI porcentHP;
    [SerializeField] Image fillHP; 
    [SerializeField] Image fillDamageEntry;
    [SerializeField] Animator panelScreen;

    bool needUpdateHelathBar;

    float targetFillAmount;

    PlayerInteractions player;

    private void Start()
    {
        player = FindObjectOfType<PlayerInteractions>();
    }
    private void Update()
    {
        if(needUpdateHelathBar)
        {
            UpdateFillDamageEntry();
        }
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
            fillDamageEntry.fillAmount -= Time.deltaTime;
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