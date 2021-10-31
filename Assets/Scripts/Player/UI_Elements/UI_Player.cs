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
        porcentHP.text = porcentActualHP.ToString() + "%";

        UpdateFillHP(updateHealthPoints, maxHelathPointsPlayer);
    }

    void UpdateFillHP(float updateHealthPoints, float maxHelathPointsPlayer)
    {
        float damageToHP = updateHealthPoints / maxHelathPointsPlayer;
        fillHP.fillAmount = damageToHP;
    }

    void UpdateFillDamageEntry()
    {

    }

    public void OpenAndClosePanelPlayer()
    {
        panelScreen.SetBool("PanelIsOpen", !panelScreen.GetBool("PanelIsOpen"));
    }
}