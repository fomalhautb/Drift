using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	private float startTime;

	public void StartTimer()
	{
		startTime = Time.time;
	}

	public float ReadTimer()
	{
		return Time.time - startTime;
	}

	public void ResetTime()
	{
		startTime = Time.time;
	}
}
	