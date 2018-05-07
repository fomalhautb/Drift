using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
	public Transform[] SpawnPoints = new Transform[4];
	public InGameUI inGameUI;
	public TriggerManager triggerManager;

	private int playerId;
	private float gameStartTime;
	private float roundStartTime;

	[SyncVar] int currentPlayerNumber = 0;

	public void spawnPlayer(GameObject car)
	{
		currentPlayerNumber += 1;
	}

	public void StartGame()
	{
		StartGameTime ();
	}

	void Update()
	{
		UpdateGameTime ();
	}

	void UpdateGameTime()
	{
		if (triggerManager.currentRound > 0)
		{
			inGameUI.UpdateTimeUI (triggerManager.currentRound, Time.time - roundStartTime, Time.time - gameStartTime);
		}
	}

	void StartGameTime()
	{
		roundStartTime = Time.time;
		if (gameStartTime == 0)
		{
			gameStartTime = Time.time;
		}
	}
}