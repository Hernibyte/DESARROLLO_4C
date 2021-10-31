using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDescription : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void ShowHoverDescription()
    {
        if (animator == null)
            return;

        animator.SetBool("HoverIsOpen", true);
    }

    public void HideHoverDescription()
    {
        if (animator == null)
            return;

        animator.SetBool("HoverIsOpen", false);
    }
}
