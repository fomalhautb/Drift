using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

	private List<TriggerController> triggers = new List<TriggerController>();
	private int currentTrigger = 0;

	void Start () 
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<TriggerController> ().manager = this;
			triggers.Add (child.GetComponent<TriggerController>());
			child.gameObject.SetActive (false);
		}
		NextTrigger ();
	}

	public void NextTrigger()
	{
		triggers [currentTrigger].gameObject.SetActive (true);
		if (currentTrigger < triggers.Count - 1)
		{
			currentTrigger += 1;
		} else
		{
			currentTrigger = 0;
		}
	}
}
