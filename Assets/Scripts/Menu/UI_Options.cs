using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    [SerializeField] Scrollbar masterVolume;
    RTPCController rtpcController;

    void Start()
    {
        rtpcController = FindObjectOfType<RTPCController>();
    }

    public void ChangeMasterVolume()
    {
        rtpcController.ChangeMasterVolume((masterVolume.value * 100));
    }
}
