using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsOnPanel : MonoBehaviour
{
    [Header("BASIC STATS AND EXTRA [TEXTS]")]
    [SerializeField] TextMeshProUGUI basicHP;
    [SerializeField] TextMeshProUGUI cardsExtraHP;
    [SerializeField] TextMeshProUGUI basicDEF;
    [SerializeField] TextMeshProUGUI cardsExtraDEF;
    [SerializeField] TextMeshProUGUI basicDMG;
    [SerializeField] TextMeshProUGUI cardsExtraDMG;
    [SerializeField] TextMeshProUGUI basicVEL;
    [SerializeField] TextMeshProUGUI cardsExtraVEL;

    public void StartDefaulPanelStats(float basicHP, float basicDEF, float basicDMG, float basicVEL)
    {
        this.basicHP.text = "HP:" + basicHP;
        cardsExtraHP.text = "";

        this.basicDEF.text = "DEF:" + basicDEF;
        cardsExtraDEF.text = "";

        this.basicDMG.text = "DMG:" + basicDMG;
        cardsExtraDMG.text = "";

        this.basicVEL.text = "VEL:" + basicVEL;
        cardsExtraVEL.text = "";
    }
    public void UpdateStat(float basicHP, float extraHP, float basicDEF, float extraDEF,
        float basicDMG, float extraDMG, float basicVEL, float extraVEL)
    {
        this.basicHP.text = "HP:" + basicHP;
        if(!CheckIfSpecIsNegative(extraHP , cardsExtraHP))
            cardsExtraHP.text = " +" + extraHP;
        else
            cardsExtraHP.text = " " + extraHP;

        this.basicDEF.text = "DEF:" + basicDEF;
        if(!CheckIfSpecIsNegative(extraDEF , cardsExtraDEF))
            cardsExtraDEF.text = " +" + extraDEF;
        else
            cardsExtraDEF.text = " " + extraDEF;

        this.basicDMG.text = "DMG:" + basicDMG;
        if(!CheckIfSpecIsNegative(extraDMG, cardsExtraDMG))
            cardsExtraDMG.text = " +" + extraDMG;
        else
            cardsExtraDMG.text = " " + extraDMG;

        this.basicVEL.text = "VEL:" + basicVEL;
        if(!CheckIfSpecIsNegative(extraVEL, cardsExtraVEL))
            cardsExtraVEL.text = " +" + extraVEL;
        else
            cardsExtraVEL.text = " " + extraVEL;
    }

    bool CheckIfSpecIsNegative(float spec, TextMeshProUGUI textSpec)
    {
        if (spec < 0)
        {
            textSpec.color = Color.red;
            return true;
        }
        else
        {
            textSpec.color = Color.green;
            return false;
        }
    }
}
