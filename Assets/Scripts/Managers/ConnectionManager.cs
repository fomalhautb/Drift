using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionManager : NetworkDiscovery
{
	public void StartServer()
	{
		Initialize ();
		broadcastData = Network.player.ipAddress;
		StartAsServer ();
		GlobalManager.isServer = true;
	}

	public void StartClient()
	{
		Initialize ();
		StartAsClient ();
		GlobalManager.isServer = false;
	}

	public void CloseConnection()
	{
		StopBroadcast ();
		GlobalManager.isServer = false;
	}

	public override void OnReceivedBroadcast(string fromAddress, string data)
	{
		Debug.Log (fromAddress + "   " + data);
		if (true)//(isServer)
		{
			GlobalManager.serverIP = data;
		}
	}
}
