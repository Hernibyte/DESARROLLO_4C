using UnityEngine;

public class ConnectionAnimBehaviour : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event attackEvent;
    [SerializeField] AK.Wwise.Event attackEventVariant;
    [SerializeField] AK.Wwise.Event reciveDamageEvent;
    [SerializeField] AK.Wwise.Event footStepEvent;

    [Header("Extra Animations")]
    [Space(15)]
    [SerializeField] AK.Wwise.Event extraSoundAnim_1;
    [SerializeField] AK.Wwise.Event extraSoundAnim_2;
    [SerializeField] AK.Wwise.Event extraSoundAnim_3;


    private void OnDisable()
    {
    //--------------------------------------
        attackEvent.Stop(gameObject);
        attackEventVariant.Stop(gameObject);
        reciveDamageEvent.Stop(gameObject);
        footStepEvent.Stop(gameObject);
    //--------------------------------------
        extraSoundAnim_1.Stop(gameObject);
        extraSoundAnim_2.Stop(gameObject);
        extraSoundAnim_3.Stop(gameObject);
    //--------------------------------------
    }

    //=========================================================

    public void MakeSoundAttack_1()
    {
        attackEvent.Post(gameObject);
    }

    public void MakeSoundAttack_2()
    {
        attackEventVariant.Post(gameObject);
    }

    public void MakeSoundHitRecived()
    {
        reciveDamageEvent.Post(gameObject);
    }

    public void MakeFootStepEvent()
    {
        footStepEvent.Post(gameObject);
    }

    //=========================================================

    public void ExecuteExtraSoundAnimation_1()
    {
        extraSoundAnim_1.Post(gameObject);
    }

    public void ExecuteExtraSoundAnimation_2()
    {
        extraSoundAnim_2.Post(gameObject);
    }

    public void ExecuteExtraSoundAnimation_3()
    {
        extraSoundAnim_3.Post(gameObject);
    }

    //=========================================================
}
