using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] StatsManager statsManager;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] UI_Manager uiManager;
    public CameraBehaviour cameraBehaviour;
    public Transform playerTransform;
    public GameObject playerDodgePivot;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            uiManager.uiPlayer.OpenAndClosePanelPlayer();
        }
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
        //
        statsManager.GetPlayerStatsReference();
    }
}
