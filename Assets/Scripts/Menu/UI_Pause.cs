using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Pause : MonoBehaviour
{
    [SerializeField ] UnityEvent resume;
    [SerializeField] UnityEvent backToMenu;

    public void Resume()
    {
        resume?.Invoke();
    }

    public void BackToMenu()
    {
        backToMenu?.Invoke();
    }
}
