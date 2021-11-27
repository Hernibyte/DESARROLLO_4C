using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UILoadingScreenBehaviour : MonoBehaviour
{
    [SerializeField] GameObject m_TextContinue;
    [SerializeField] GameObject m_TextLoading;
    [SerializeField] UnityEvent close;
    bool closeLoadingScreen;

    void Start()
    {
        m_TextContinue.SetActive(false);
        m_TextLoading.SetActive(true);
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
        m_TextContinue.SetActive(true);
        m_TextLoading.SetActive(false);
    }
}
