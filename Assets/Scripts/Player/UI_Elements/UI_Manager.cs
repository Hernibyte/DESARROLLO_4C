using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public UI_Player uiPlayer;
    [SerializeField] GameObject uiPause;

    void Awake()
    {
        uiPause.SetActive(false);
    }

    public void ChangePauseView(bool state)
    {
        uiPause.SetActive(state);
    }
}