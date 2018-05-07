using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour 
{
	private float startTime;

	public void startTimer()
	{
		startTime = Time.time;
	}

	public float readTimer()
	{
		return Time.time - startTime;
	}
}
