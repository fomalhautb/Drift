using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject focus;
	public float height;
	public float distance;
	public float rotationLerpSpeed;
	public float moveLerpSpeed;
	public float cameraAngle;
	public float cameraMovementLimit;

	void Start () 
	{
		
	}

	void FixedUpdate () 
	{
		if (focus != null)
		{
			if (focus.GetComponent<Rigidbody> ().velocity.magnitude > cameraMovementLimit)
			{
				Vector3 camRot = new Vector3 (cameraAngle, Quaternion.LookRotation (focus.GetComponent<Rigidbody> ().velocity).eulerAngles.y, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(camRot), rotationLerpSpeed * Time.fixedDeltaTime);
				Vector3 camPos = focus.transform.position + Vector3.up * height + focus.GetComponent<Rigidbody> ().velocity.normalized * distance;
				transform.position = Vector3.Lerp (transform.position, camPos, moveLerpSpeed*Time.fixedDeltaTime);
			}
		}
	}
}
