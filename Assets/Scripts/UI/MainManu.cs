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
		//start to broadcast the ip, callback of play as server button
		conMan.StartServer();
		OpenWaitingUI ();
	}

	public void PlayAsClient()
	{
		//start to listen the ip, callback of play as client button
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
		//callback of back button
		conMan.CloseConnection ();
		mainUI.SetActive (true);
		waitingUI.SetActive (false);
	}

	public void Ready()
	{
		//callback of ready button
		SceneManager.LoadScene ("Town");
	}

	public void ChoiceCarLeft()
	{
		//callback of left button
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
		//callback of right button
		currentCarIndex = currentCarIndex + 1;
		if (currentCarIndex >= Cars.Length)
		{
			currentCarIndex = 0;
		}
		InstantiateCar (currentCarIndex);
	}

	public void InstantiateCar(int index)
	{
		//change the car on the exhibition
		if (currentCar)
		{
			Destroy (currentCar);
		}
		currentCar = Instantiate (Cars [index], exhibition.transform);
		currentCar.transform.position = Vector3.zero;
		GlobalManager.playerCarIndex = index;
	}
}
