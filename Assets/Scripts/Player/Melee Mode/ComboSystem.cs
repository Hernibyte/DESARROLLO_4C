using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    #region Singleton
    private static ComboSystem instance;
    public static ComboSystem Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public bool canReciveInput;
    public bool inputRecived;
    public bool canAttack = false;

    private void Start()
    {
        canAttack = true;
    }
    private void Update()
    {
        IntedAttack();
    }

    public void IntedAttack()
    {
        if (!canAttack)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (canReciveInput)
            {
                inputRecived = true;
                canReciveInput = false;
            }
            else
            {
                return;
            }
        }
    }

    public void InputHandler()
    {
        if (!canReciveInput)
        {
            canReciveInput = true;
        }
        else
        {
            canReciveInput = false;
        }
    }
}
