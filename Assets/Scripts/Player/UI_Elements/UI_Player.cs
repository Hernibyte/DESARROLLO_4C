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

    private void Update()
    {
        
    }

    public void UpdateUIPlayer(float updateHealthPoints, float maxHelathPointsPlayer)
    {
        float porcentActualHP = (updateHealthPoints * 100) / maxHelathPointsPlayer;
        porcentHP.text = porcentActualHP.ToString() + "%";


    }

    void UpdateFillHP()
    {

    }

    public void OpenAndClosePanelPlayer()
    {
        panelScreen.SetBool("PanelIsOpen", !panelScreen.GetBool("PanelIsOpen"));
    }
}