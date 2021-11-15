using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enemies : MonoBehaviour
{
    [SerializeField] Image hpFill;
    [SerializeField] Image damageFill;

    CanvasGroup groupAlapha;
    bool needUpdateHealthBar;
    float targetDamnageFill;
    EnemyInteractions enemyData;

    void Start()
    {
        needUpdateHealthBar = false;
        groupAlapha = GetComponent<CanvasGroup>();
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
            damageFill.fillAmount -= Time.deltaTime / targetDamnageFill;
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

    public void HideUIEnemy()
    {
        if (groupAlapha == null)
            return;

        IEnumerator FadeCanvas()
        {
            while (groupAlapha.alpha > 0)
            {
                groupAlapha.alpha -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            groupAlapha.alpha = 0;
        }
        StartCoroutine(FadeCanvas());
    }
}
