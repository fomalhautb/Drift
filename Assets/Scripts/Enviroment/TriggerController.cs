using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour 
{
	public float hideDelay;
	public TriggerManager manager;

	void OnTriggerEnter(Collider other)
	{
		manager.NextTrigger ();
		StartCoroutine ("HideTrigger", hideDelay);
	}

	private IEnumerator HideTrigger(float delay)
	{
		yield return new WaitForSeconds(delay);
		gameObject.SetActive (false);
	}
}
