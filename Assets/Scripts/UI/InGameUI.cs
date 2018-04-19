using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour 
{
	public Text roundTimeUI;
	public Text totalTimeUI;

	public void ChangeMainCamView()
	{
		int viewNumber = Camera.main.GetComponent<CameraMovement> ().height.Length;
		Camera.main.GetComponent<CameraMovement> ().currentCamNumber = (Camera.main.GetComponent<CameraMovement> ().currentCamNumber + 1) % viewNumber;
	}

	public void UpdateTimeUI(int round, float roundTime, float totalTime)
	{
		roundTimeUI.text = "round " + round.ToString () + " time: " + roundTime.ToString ("F");
		totalTimeUI.text = "total time: " + totalTime.ToString ("F");
	}
}
