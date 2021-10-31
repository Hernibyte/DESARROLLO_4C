using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enemies : MonoBehaviour
{
    [SerializeField] Image hpFill;
    [SerializeField] Image damageFill;

    bool needUpdateHealthBar;
    float targetDamnageFill;
    EnemyInteractions enemyData;

    void Start()
    {
        needUpdateHealthBar = false;
        enemyData = gameObject.GetComponentInParent<EnemyInteractions>();
        
        if(enemyData != null)
            enemyData.hasRecivedDamage.AddListener(UpdateEnemyHealthBar);
    }

    private void Update()
    {
        if(needUpdateHealthBar)
        {
            UpdateDamageFill();
        }
    }

    void UpdateEnemyHealthBar(float updateHealthPoints, float maxHealthPoints)
    {
        UpdateHPFill(updateHealthPoints, maxHealthPoints);
    }

    void UpdateHPFill(float updateHealthPoints, float maxHealthPoints)
    {
        float damageToHP = updateHealthPoints / maxHealthPoints;
        hpFill.fillAmount = damageToHP;

        targetDamnageFill = damageToHP;
        StartCoroutine(DelayToUpdateDamageFill());
    }

    void UpdateDamageFill()
    {
        if (damageFill.fillAmount > targetDamnageFill)
            damageFill.fillAmount -= Time.deltaTime;
        else
        {
            damageFill.fillAmount = targetDamnageFill;
            needUpdateHealthBar = false;
        }
    }

    IEnumerator DelayToUpdateDamageFill()
    {
        yield return new WaitForSeconds(0.15f);
        needUpdateHealthBar = true;
    }
}
