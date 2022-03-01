using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [HideInInspector] public Vector2 teleportPosition;
    [HideInInspector] public bool isGateOpen;
    [SerializeField] private bool keyNeeded = false;
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
            {
                //AkSoundEngine.PostEvent("enter_room", gameObject);
                other.transform.position = teleportPosition;
            }
    }
}
