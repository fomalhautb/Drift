using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject focus;
	public float[] height;
	public float[] distance;
	public float[] cameraAngle;

	public bool[] rotVelocityDirection;
	public bool[] moveVelocityDirection;
	public float[] rotationLerpSpeed;
	public float[] moveLerpSpeed;

	public int currentCamNumber = 1;

	void Start () 
	{
		
	}

	void FixedUpdate () 
	{
		if (focus != null)
		{
			Vector3 camRot;
			Vector3 camPos;

			if (rotVelocityDirection[currentCamNumber])
			{
				camRot = new Vector3 (cameraAngle[currentCamNumber], Quaternion.LookRotation (focus.GetComponent<Rigidbody> ().velocity).eulerAngles.y, 0);
			} else
			{
				camRot = new Vector3 (cameraAngle[currentCamNumber], focus.transform.rotation.eulerAngles.y, 0);
			}
			if (moveVelocityDirection[currentCamNumber])
			{
				camPos = focus.transform.position + Vector3.up * height[currentCamNumber] + focus.GetComponent<Rigidbody> ().velocity.normalized * distance[currentCamNumber];
			} else
			{
				camPos = focus.transform.position + Vector3.up * height[currentCamNumber] + focus.transform.forward * distance[currentCamNumber];
			}

			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(camRot), rotationLerpSpeed[currentCamNumber] * Time.fixedDeltaTime);
			transform.position = Vector3.Lerp (transform.position, camPos, moveLerpSpeed[currentCamNumber]*Time.fixedDeltaTime);
		}
	}
}
