using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2 teleportPosition;
    [HideInInspector] public bool isGateOpen;
    [SerializeField] LayerMask playerMask;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(isGateOpen)
        {
            if(MyUtilities.Contains(playerMask, other.gameObject.layer))
            {
                other.transform.position = teleportPosition;
            }
        }
    }
}
