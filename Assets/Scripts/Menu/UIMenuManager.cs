using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] GameObject uiCreditsObject;
    [SerializeField] GameObject uiOptionsObject;
    [SerializeField] GameObject uiLoading;
    [SerializeField] Text gameVersion;

    void Awake()
    {
        AkSoundEngine.PostEvent("inicio_menu", gameObject);

        uiCreditsObject.SetActive(false);
        uiOptionsObject.SetActive(false);
        uiLoading.SetActive(false);

        gameVersion.text = "v" + Application.version;
    }

    public void Play()
    {
        ChangeScene("Game");
    }

    public void Options(bool state)
    {
        uiOptionsObject.SetActive(state);
    }

    public void Credits(bool state)
    {
        uiCreditsObject.SetActive(state);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        uiLoading.SetActive(true);
        StartCoroutine(LoadingScene(sceneName));
    }

    IEnumerator LoadingScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        yield return operation.isDone;
    }
}
