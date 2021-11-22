using UnityEngine;

public class UI_SfxController : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event soundOnEnter;
    [SerializeField] AK.Wwise.Event soundOnPress;

    public void PlayeOnEnterSfx()
    {
        soundOnEnter.Post(gameObject);
    }

    public void PlayeOnPressSfx()
    {
        soundOnPress.Post(gameObject);
    }
}