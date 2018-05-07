using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoConnection: MonoBehaviour
{

	void Start () 
	{
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
