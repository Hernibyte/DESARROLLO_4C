using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatSystem : MonoBehaviour
{
    [SerializeField] GameObject inputField;
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
                pj.totalMaxHP = 100000f;
                pj.lifeAmount = 100000f;
                pj.totalDamageMelee = 100000;
                pj.totalDamageRange = 100000;
                pj.totalForceMovement = 300;//Es dios dejalo romper el cap pa
                break;
            case "max damage":
                pj.totalDamageMelee = 100000;
                pj.totalDamageRange = 100000;
                break;
            case "max hp":
                pj.totalMaxHP = 1000000f;
                pj.lifeAmount = 1000000f;
                break;
        }

        uiManager.uiPlayer.UpdateStatsAfterCheat();
    }
}
