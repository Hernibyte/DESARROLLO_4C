using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UILoadingScreenBehaviour : MonoBehaviour
{
    [SerializeField] GameObject mText;
    [SerializeField] UnityEvent close;
    bool closeLoadingScreen;

    void Start()
    {
        mText.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && closeLoadingScreen)
        {
            close?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void Close()
    {
        closeLoadingScreen = true;
        mText.SetActive(true);
    }
}
