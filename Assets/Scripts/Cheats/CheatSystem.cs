using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatSystem : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    [SerializeField] private int godModeMaxHp = 0;
    [SerializeField] private int cheatMaxHP = 0;
    UI_Manager uiManager;
    bool inputState;

    private void Start()
    {
        uiManager = FindObjectOfType<UI_Manager>();
        inputField.SetActive(inputState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            inputState = !inputState;
            if (inputState)
                inputField.SetActive(true);
            else
                inputField.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputState)
        {
            inputField.SetActive(false);
            inputState = false;
        }
    }

    public void ActivateCommand()
    {
        string command = inputField.GetComponent<InputField>().text;
        PlayerStats pj = FindObjectOfType<PlayerStats>();

        switch (command)
        {
            case "god":
                pj.maxHearts = godModeMaxHp;
                pj.heartsAmount = godModeMaxHp;
                pj.totalDamageMelee = 100000;
                pj.totalDamageRange = 100000;
                pj.totalForceMovement = 300;//Es dios dejalo romper el cap pa
                break;
            case "max damage":
                pj.totalDamageMelee = 100000;
                pj.totalDamageRange = 100000;
                break;
            case "max hp":
                pj.maxHearts = cheatMaxHP;
                pj.heartsAmount = cheatMaxHP;
                break;
            case "oh crap":
                pj.maxHearts = 1;
                pj.heartsAmount = 1;
                pj.totalDamageMelee = 1;
                pj.totalDamageRange = 1;
                pj.totalForceMovement = 160;
                break;
        }

        uiManager.uiPlayer.UpdateStatsAfterCheat();
        
    }
}
