using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarLight : MonoBehaviour 
{
	public Light light;
	public float lightTime;

	private Timer timer;

	public void Start()
	{
		timer = new Timer ();
		timer.StartTimer ();
	}
	public void Update()
	{
		if (timer.ReadTimer () >= lightTime)
		{
			if (light.color == Color.red)
			{
				light.color = Color.blue;
			} else
			{
				light.color = Color.red;
			}
			timer.ResetTime ();
		}
	}
}
