using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour 
{
	public ConnectionManager conMan;
	public GameObject mainUI;
	public GameObject waitingUI;

	public void PlayAsServer()
	{
		conMan.StartServer();
		OpenWaitingUI ();
	}

	public void PlayAsClient()
	{
		conMan.StartClient ();
		OpenWaitingUI ();
	}

	void OpenWaitingUI()
	{
		mainUI.SetActive (false);
		waitingUI.SetActive (true);
	}

	public void BackToMainMenu()
	{
		conMan.CloseConnection ();
		mainUI.SetActive (true);
		waitingUI.SetActive (false);
	}

	public void Ready()
	{
		SceneManager.LoadScene ("Town");
	}
}
