using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoConnection: MonoBehaviour
{
	public GameObject[] cars;
	void Start () 
	{
		GetComponent<NetworkManager> ().playerPrefab = cars[GlobalManager.playerCarIndex];
		if (GlobalManager.isServer)
		{
			GetComponent<NetworkManager> ().StartHost ();
		} else
		{
			GetComponent<NetworkManager> ().networkAddress = GlobalManager.serverIP;
			GetComponent<NetworkManager> ().StartClient ();
		}
	}
}
