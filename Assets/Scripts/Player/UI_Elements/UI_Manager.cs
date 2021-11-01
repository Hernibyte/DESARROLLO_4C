using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public UI_Player uiPlayer;
    [SerializeField] GameObject uiPause;
    [SerializeField] GameObject uiFinishedLevel;

    void Awake()
    {
        uiPause.SetActive(false);
        uiFinishedLevel.SetActive(false);
    }

    public void ChangePauseView(bool state)
    {
        uiPause.SetActive(state);
    }

    public void ChangeFinishedLevelView(bool state)
    {
        uiFinishedLevel.SetActive(state);
    }
}