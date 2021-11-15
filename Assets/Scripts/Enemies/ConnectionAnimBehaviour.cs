using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionAnimBehaviour : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event attackEvent;
    [SerializeField] AK.Wwise.Event reciveDamageEvent;
    [SerializeField] AK.Wwise.Event footStepEvent;

    public void MakeSoundAttack()
    {
        attackEvent.Post(gameObject);
    }

    public void MakeSoundHitRecived()
    {
        reciveDamageEvent.Post(gameObject);
    }

    public void MakeFootStepEvent()
    {
        footStepEvent.Post(gameObject);
    }
}
