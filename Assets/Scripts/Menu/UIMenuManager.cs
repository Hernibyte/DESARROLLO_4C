using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] GameObject uiCreditsObject;
    [SerializeField] GameObject uiOptionsObject;

    void Awake()
    {
        uiCreditsObject.SetActive(false);
        uiOptionsObject.SetActive(false);
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
        StartCoroutine(LoadingScene(sceneName));
    }

    IEnumerator LoadingScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        yield return operation.isDone;
    }
}
