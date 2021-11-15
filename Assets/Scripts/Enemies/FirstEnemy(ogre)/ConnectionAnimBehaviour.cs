using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionAnimBehaviour : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event attackEvent;
    [SerializeField] AK.Wwise.Event reciveDamageEvent;

    public void MakeSoundAttack()
    {
        attackEvent.Post(gameObject);
    }

    public void MakeSoundHitRecived()
    {
        reciveDamageEvent.Post(gameObject);
    }
}
