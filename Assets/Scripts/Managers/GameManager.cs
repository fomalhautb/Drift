using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
	public Transform[] SpawnPoints = new Transform[4];
	public InGameUI inGameUI;
	public TriggerManager triggerManager;
	public int playerId;

	private Timer gameTimer = new Timer();
	private Timer roundTimer = new Timer();
	private float[] playerTime = new float[20];

	//[SyncVar] int currentPlayerNumber = 0;

	public void StartGame()
	{
		gameTimer.StartTimer ();
	}

	void Update()
	{
		UpdateGameTime ();
	}

	void UpdateGameTime()
	{
		//show the game time
		if (triggerManager.currentRound > 0)
		{
			inGameUI.UpdateTimeUI (triggerManager.currentRound, roundTimer.ReadTimer(), gameTimer.ReadTimer());
		}
		//CmdSendTime (gameTimer.ReadTimer ());
	}

	public void StartRoundTime()
	{
		roundTimer.StartTimer ();
	}

	[Command] void CmdSendTime(float time, int id)
	{
		playerTime [id] = time;
	}
}