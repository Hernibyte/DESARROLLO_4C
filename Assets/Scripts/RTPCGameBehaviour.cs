using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTPCGameBehaviour : MonoBehaviour
{
    RTPCController controller;

    void Awake()
    {
        controller = FindObjectOfType<RTPCController>();
    }

    public void SetValue()
    {
        controller.UpdatemasterVolume();
    }
}
