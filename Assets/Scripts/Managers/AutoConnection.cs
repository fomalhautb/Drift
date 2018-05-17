using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoConnection: MonoBehaviour
{
	public GameObject[] cars;
	void Start () 
	{
		//set the player prefab to spawn
		GetComponent<NetworkManager> ().playerPrefab = cars[GlobalManager.playerCarIndex];
		if (GlobalManager.isServer)
		{
			//start the server
			GetComponent<NetworkManager> ().StartHost ();
		} else
		{
			//connet to the server
			GetComponent<NetworkManager> ().networkAddress = GlobalManager.serverIP;
			GetComponent<NetworkManager> ().StartClient ();
		}
	}
}
