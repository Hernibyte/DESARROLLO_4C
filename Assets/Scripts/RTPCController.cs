﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTPCController : MonoBehaviour
{
    public float tempValue;

    static RTPCController instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdatemasterVolume();
    }

    void LateUpdate()
    {
        UpdatemasterVolume();
    }

    public void ChangeMasterVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("rtpc_mastervolume", value);
        tempValue = value;
    }

    public void UpdatemasterVolume()
    {
        AkSoundEngine.SetRTPCValue("rtpc_mastervolume", tempValue);
    }
}
