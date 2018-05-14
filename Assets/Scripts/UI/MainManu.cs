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
	public GameObject exhibition;
	public GameObject[] Cars;

	private int currentCarIndex = 0;
	private GameObject currentCar;

	public void Start()
	{
		InstantiateCar (0);
	}

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

	public void ChoiceCarLeft()
	{
		currentCarIndex = currentCarIndex - 1;
		if (currentCarIndex < 0)
		{
			currentCarIndex = Cars.Length - 1;
		}
		Debug.Log (currentCarIndex);
		InstantiateCar (currentCarIndex);
	}

	public void ChoiceCarRight()
	{
		currentCarIndex = currentCarIndex + 1;
		if (currentCarIndex >= Cars.Length)
		{
			currentCarIndex = 0;
		}
		InstantiateCar (currentCarIndex);
	}

	public void InstantiateCar(int index)
	{
		if (currentCar)
		{
			Destroy (currentCar);
		}
		currentCar = Instantiate (Cars [index], exhibition.transform);
		currentCar.transform.position = Vector3.zero;
		GlobalManager.playerCarIndex = index;
	}
}
