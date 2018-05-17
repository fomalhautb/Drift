using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour 
{
	//the rotation of the exibition
	public float autoRotateSpeed;
	public float mouseRotateSpeed;
	void FixedUpdate () 
	{
		//rotate the car while the mouse drag
		if (Input.GetMouseButton (0))
		{
			transform.Rotate(-Vector3.up * mouseRotateSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse X"));
		} else
		{
			transform.Rotate (Vector3.up * autoRotateSpeed * Time.fixedDeltaTime);
		}
	}
}
