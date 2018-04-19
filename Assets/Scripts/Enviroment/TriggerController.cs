using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour 
{
	public TriggerManager manager;

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.root.tag == "Player")
		{
			manager.NextTrigger ();
		}
	}
}
