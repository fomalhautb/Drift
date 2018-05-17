using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

	public float hideDelay;
	public GameManager gameManager;
	[HideInInspector]public int currentTrigger = 0;
	[HideInInspector]public int currentRound = 0;
	private bool firstRound = true;

	private ArrayList triggers = new ArrayList();
	private ArrayList lastTrigger;

	void Start () 
	{
		foreach (Transform child in transform)
		{
			ArrayList childTriggers = new ArrayList (); 
			if (child.GetComponent<TriggerController>() != null)
			{
				child.GetComponent<TriggerController> ().manager = this;
				childTriggers.Add (child.GetComponent<TriggerController> ());
				child.gameObject.SetActive (false);
			} else
			{
				foreach (Transform trigger in child)
				{
					trigger.GetComponent<TriggerController> ().manager = this;
					childTriggers.Add (trigger.GetComponent<TriggerController> ());
					trigger.gameObject.SetActive (false);
				}
			}
			triggers.Add (childTriggers);
		}
		NextTrigger ();
	}

	public void NextTrigger()
	{
		if (lastTrigger != null)
		{
			foreach (object child in lastTrigger)
			{
				IEnumerator coroutine = HideTrigger (((TriggerController)child).gameObject, hideDelay);
				StartCoroutine (coroutine);
			}
		}
		if (currentTrigger == 1)
		{
			if (firstRound)
			{
				gameManager.StartGame ();
				firstRound = false;
			}
			currentRound += 1;
			gameManager.StartRoundTime ();
		}

		lastTrigger = (ArrayList)triggers [currentTrigger];
		foreach (object child in (ArrayList) triggers [currentTrigger])
		{
			((TriggerController)child).gameObject.SetActive (true);
		}
			
		if (currentTrigger < triggers.Count-1)
		{
			currentTrigger += 1;
		} else
		{
			currentTrigger = 0;
		}
		//Debug.Log ("round: " + currentRound.ToString() + ", round time: " + (Time.time-roundStartTime).ToString() + ", total time: " + (Time.time-gameStartTime).ToString());
	}

	private IEnumerator HideTrigger(GameObject target, float delay)
	{
		yield return new WaitForSeconds(delay);
		target.SetActive (false);
	}
}
