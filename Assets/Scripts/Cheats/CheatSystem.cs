using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatSystem : MonoBehaviour
{
    [SerializeField] GameObject inputField;
    bool inputState;

    private void Start()
    {
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
        //UI_Boss bossRef = FindObjectOfType<UI_Boss>();
        //
        switch (command)
        {
            case "god":
                pj.maxHp = 1000000f;
                pj.lifeAmount = 1000000f;
                pj.damageMeleeAttack = 100000;
                pj.damageRangeAttack = 100000;
                pj.forceMovement = 500;//Es dios dejalo romper el cap pa
                break;
            case "max damage":
                pj.damageMeleeAttack = 100000;
                pj.damageRangeAttack = 100000;
                break;
            case "max hp":
                pj.maxHp = 1000000f;
                pj.lifeAmount = 1000000f;
                break;
            //case "tp BossRoom":
            //    //int index = rp.roomList.Count - 1;
            //    //Vector3 bossPosition = rp.roomList[index].transform.position;
            //    //pj.gameObject.transform.position = bossPosition;
            //    break;
            //case "actuallyDefy":
            //    if(bossRef.boss != null)
            //    {
            //        bossRef.boss.bossMAX_HP = 5000000f;
            //        bossRef.boss.bossDamage = 5000;
            //        bossRef.boss.bossSpeed = 6f;
            //    }
            //    else
            //    {
            //        Debug.Log("NULO BOSSS");
            //    }
            //    break;
            //case "heal!":
            //    //pj.FullHealPlayer();
            //    break;
        }
    }
}
