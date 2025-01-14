﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] StatsManager statsManager;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] UI_Manager uiManager;
    [SerializeField] LootManager lootManager;
    public CameraBehaviour cameraBehaviour;
    public Transform playerTransform;
    public GameObject playerDodgePivot;
    [Space(20)]
    [SerializeField] int lastIndexCardTaked;

    //Temporal
    [Space(15)]
    [SerializeField][Range(0,100)] float gameVolume;

    private void Start()
    {
        uiManager.uiPlayer.OnPanelChangeState.AddListener(ChangeStateMovementPlayer);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            HandleTabPanelAndInventory();
        //
        if(Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void OnDisable()
    {
        uiManager.uiPlayer.OnPanelChangeState.RemoveListener(ChangeStateMovementPlayer);
    }

    void HandleTabPanelAndInventory()
    {
        uiManager.uiPlayer.OpenAndClosePanelPlayer();
    }

    void ChangeStateMovementPlayer()
    {
        playerTransform.GetComponent<PlayerMovement>().canIMove = !playerTransform.GetComponent<PlayerMovement>().canIMove;
        ComboSystem.Instance.canAttack = !ComboSystem.Instance.canAttack;
    }

    public void IfLevelGenerationEnds()
    {
        GameObject obj = Instantiate(playerDodgePivot, transform.position, Quaternion.identity);
        PlayerMovement movement = Instantiate(playerPrefab, transform.position, Quaternion.identity).GetComponent<PlayerMovement>();
        playerTransform = movement.transform;
        movement.dodgePivot = obj.transform;

        PlayerInteractions playerInteractions = movement.GetComponent<PlayerInteractions>();
        if (playerInteractions != null)
            playerInteractions.hasRecivedDamage.AddListener(uiManager.uiPlayer.UpdateUIPlayer);

        Player player = movement.GetComponent<Player>();
        player.die.AddListener(PlayerIsDead);
        //
        statsManager.GetPlayerStatsReference();
        uiManager.uiPlayer.StartStatsPanel();
        uiManager.uiPlayer.UpdateUIPlayer(statsManager.playerStats.heartsAmount, statsManager.playerStats.maxHearts);
    }

    public void HealPlayer(int amountHearts)
    {
        if (statsManager.playerStats.heartsAmount < statsManager.playerStats.maxHearts)
            statsManager.playerStats.heartsAmount += amountHearts;
        else
            statsManager.playerStats.heartsAmount = statsManager.playerStats.maxHearts;

        uiManager.uiPlayer.UpdateUIPlayer(statsManager.playerStats.heartsAmount, statsManager.playerStats.maxHearts);
    }

    void PlayerIsDead()
    {
        uiManager.ChangePlayerDiedView();
        Time.timeScale = 0;
    }

    public void FinishedLevel()
    {
        uiManager.ChangeFinishedLevelView(true);
        Time.timeScale = 0;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        StartCoroutine(ReloadGameScene());
    }

    IEnumerator ReloadGameScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        yield return operation;
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            AkSoundEngine.PostEvent("pausa_in", gameObject);
            uiManager.ChangePauseView(true);
            Time.timeScale = 0;
        }
        else 
        {
            AkSoundEngine.PostEvent("pausa_out", gameObject);
            uiManager.ChangePauseView(false);
            Time.timeScale = 1;
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        AkSoundEngine.PostEvent("pausa_out", gameObject);
        StartCoroutine(LoadMenuScene());
    }

    IEnumerator LoadMenuScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Menu");
        yield return operation;
    }
}
