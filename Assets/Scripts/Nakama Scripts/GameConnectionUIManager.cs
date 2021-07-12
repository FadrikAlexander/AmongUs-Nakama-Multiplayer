﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConnectionUIManager : MonoBehaviour
{
    [SerializeField] GameObject serverConnectingText;
    [SerializeField] GameObject serverConnectedText;
    [SerializeField] GameObject findMatchButton;
    [SerializeField] GameObject CancelMatchButton;
    [SerializeField] GameObject findingMatchText;
    [SerializeField] GameObject isHostGameObject;
    [SerializeField] Text playerCountText;
    [SerializeField] InputField nameInputField;

    [Header("In Game Panel")]
    [SerializeField] GameObject inGameUIPanel;


    GameConnectionManager gameConnectionManager;

    void Awake()
    {
        gameConnectionManager = FindObjectOfType<GameConnectionManager>();

        serverConnectingText.SetActive(true);

        serverConnectedText.SetActive(false);
        findMatchButton.SetActive(false);
        CancelMatchButton.SetActive(false);
        playerCountText.gameObject.SetActive(false);
        findingMatchText.SetActive(false);
        inGameUIPanel.SetActive(false);
        isHostGameObject.SetActive(false);
        nameInputField.gameObject.SetActive(false);
    }

    public void ResetUI()
    {
        serverConnectedText.SetActive(true);
        findMatchButton.SetActive(true);
        nameInputField.gameObject.SetActive(true);

        CancelMatchButton.SetActive(false);
        playerCountText.gameObject.SetActive(false);
        findingMatchText.SetActive(false);
        inGameUIPanel.SetActive(false);
        isHostGameObject.SetActive(false);

        FindObjectOfType<MeetingsManager>().ResetMeeting();
    }

    #region Buttons
    public async void FindMatch()
    {
        ActivateFindingMatchUI();

        await gameConnectionManager.FindMatch();
    }
    public async void LeaveMatch()
    {
        await gameConnectionManager.LeaveMatch();
    }
    public async void CancelMatchMaking()
    {
        await gameConnectionManager.CanelMatchMacking();

        ActivateCancelMatchMaking();
    }
    #endregion

    #region UI Manipulations
    public void ActivateServerConnected()
    {
        serverConnectingText.SetActive(false);
        serverConnectedText.SetActive(true);
        isHostGameObject.SetActive(false);

        findMatchButton.SetActive(true);
        nameInputField.gameObject.SetActive(true);
    }

    public void ActivateFindingMatchUI()
    {
        findMatchButton.SetActive(false);
        nameInputField.gameObject.SetActive(false);

        isHostGameObject.SetActive(false);

        findingMatchText.SetActive(true);
        CancelMatchButton.SetActive(true);
    }

    void ActivateCancelMatchMaking()
    {
        findMatchButton.SetActive(true);
        nameInputField.gameObject.SetActive(true);

        isHostGameObject.SetActive(false);
        findingMatchText.SetActive(false);
        CancelMatchButton.SetActive(false);
        playerCountText.gameObject.SetActive(false);
    }

    public void ActivateMatchFound()
    {
        CancelMatchButton.SetActive(false);
        findingMatchText.SetActive(false);

        inGameUIPanel.SetActive(true);
    }
    public void SetPlayerCountText(int minPlayers, int maxPlayers)
    {
        //Deactivated for clients testing
        //playerCountText.gameObject.SetActive(true);
        playerCountText.text = minPlayers + "/" + maxPlayers;
    }

    public void ActivateIsHost(bool isHost)
    {
        isHostGameObject.SetActive(isHost);
    }

    public string GetPlayerName()
    {
        return nameInputField.text;
    }
    #endregion
}
