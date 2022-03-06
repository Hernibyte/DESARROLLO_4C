using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UILoadingScreenBehaviour : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] GameObject m_TextContinue;
    [SerializeField] GameObject m_TextNext;
    [SerializeField] GameObject m_TextLoading;
    [SerializeField] CanvasGroup[] comicImages;
    [SerializeField] UnityEvent close;
    #endregion
    
    #region PRIVATE_FIELDS
    bool closeLoadingScreen;
    bool allDoneToStart = false;
    int comicsDisplayed = 0;
    int firstTime = 0;
    #endregion

    #region UNITY_CALLS
    void Start()
    {
        firstTime = PlayerPrefs.GetInt("firstTime", 0);

        m_TextContinue.SetActive(false);
        m_TextNext.SetActive(false);
        m_TextLoading.SetActive(true);

        if (firstTime >= 1)
        {
            comicsDisplayed = comicImages.Length;
            allDoneToStart = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && closeLoadingScreen && allDoneToStart)
        {
            close?.Invoke();
            gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            ShowComics();
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private void AllDoneToStart()
    {
        firstTime = 1;
        PlayerPrefs.SetInt("firstTime", firstTime);
        PlayerPrefs.Save();

        m_TextNext.SetActive(false);
        m_TextContinue.SetActive(true);
        allDoneToStart = true;
    }
    private void ShowComics()
    {
        if (AllComicsDone())
        {
            AllDoneToStart();
            return;
        }

        StartCoroutine(ShowComic());
    }
    private bool AllComicsDone()
    {
        return comicsDisplayed >= comicImages.Length;
    }
    #endregion

    #region PUBLIC_METHODS
    public void Close()
    {
        closeLoadingScreen = true;
        m_TextLoading.SetActive(false);
        ShowComics();
    }
    #endregion

    #region CORUTINES
    private IEnumerator ShowComic()
    {
        m_TextNext.SetActive(false);
        float increaseVal = 0.25f;

        while (comicImages[comicsDisplayed].alpha < 1)
        {
            if(comicsDisplayed - 1 >= 0)
            {
                comicImages[comicsDisplayed - 1].alpha -= increaseVal * Time.deltaTime;
            }

            comicImages[comicsDisplayed].alpha += increaseVal * Time.deltaTime;

            yield return null;
        }

        if(comicsDisplayed < comicImages.Length)
        {
            comicsDisplayed++;
            m_TextNext.SetActive(true);
        }

        yield break;
    }
    #endregion
}
