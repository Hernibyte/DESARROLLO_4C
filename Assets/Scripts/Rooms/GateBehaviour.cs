using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2 teleportPosition;
    [HideInInspector] public bool isGateOpen;
    [SerializeField] LayerMask playerMask;
    Animator gateAnimator;

    private void Start()
    {
        gateAnimator = GetComponentInChildren<Animator>();
    }
    public void UpdateGateAnimation()
    {
        if (gateAnimator == null)
            return;

        gateAnimator.SetBool("IsOpen", isGateOpen);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(isGateOpen)
            if(MyUtilities.Contains(playerMask, other.gameObject.layer))
                other.transform.position = teleportPosition;
    }
}
