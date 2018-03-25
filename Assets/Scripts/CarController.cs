using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarController : NetworkBehaviour
{
	[SyncVar] private Vector3 playerPos;  
	[SyncVar] private Quaternion playerRot;  
	[SyncVar] private float playerSpeed;  
	public float acceleration;
	public AnimationCurve accelerationDrag;
	public float backAcceleration;
	public AnimationCurve torque;
	public float rotateDrag;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		if (isLocalPlayer)
		{
			MoveCar ();
			ComputeCarPhysic ();
			CmdSendServerPos (transform.position, transform.rotation, GetComponent<Rigidbody> ().velocity.magnitude);
		} else
		{
			LerpPosition ();
		} 
	}

	float InputY ()
	{
		return Input.GetAxisRaw ("Vertical");
	}

	float InputX ()
	{
		return Input.GetAxisRaw ("Horizontal");
		
	}

	void MoveCar ()
	{
		if (InputY () > 0)
		{
			GetComponent<Rigidbody> ().velocity += transform.forward * acceleration * Time.fixedDeltaTime;
		} else if (InputY () < 0)
		{
			GetComponent<Rigidbody> ().velocity += -transform.forward * backAcceleration * Time.fixedDeltaTime;
		}

		if (transform.InverseTransformVector(GetComponent<Rigidbody> ().velocity).z > 0)
		{
			GetComponent<Rigidbody> ().AddTorque (InputX () * (Vector3.up * torque.Evaluate (GetComponent<Rigidbody> ().velocity.magnitude) * Time.fixedDeltaTime));
		} else
		{
			GetComponent<Rigidbody> ().AddTorque (-InputX () * (Vector3.up * torque.Evaluate (GetComponent<Rigidbody> ().velocity.magnitude) * Time.fixedDeltaTime));
		}
	}

	void ComputeCarPhysic ()
	{
		GetComponent<Rigidbody> ().velocity *= (1 - accelerationDrag.Evaluate (transform.InverseTransformVector(GetComponent<Rigidbody> ().velocity).z) * Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().angularVelocity *= (1 - rotateDrag * Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().MovePosition (new Vector3 (transform.position.x, 0, transform.position.z));
		GetComponent<Rigidbody> ().MoveRotation (Quaternion.Euler (new Vector3 (0, transform.rotation.eulerAngles.y, 0)));
	}

	void LerpPosition()  
	{  
		transform.position = Vector3.Lerp (transform.position, playerPos, (playerSpeed+2) * Time.fixedDeltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation, playerRot, (playerSpeed+2) * Time.fixedDeltaTime);
	} 

	[Command]  
	public void CmdSendServerPos(Vector3 pos, Quaternion rot, float speed)  
	{  
		playerPos = pos;  
		playerRot = rot;  
		playerSpeed = speed;
	} 
}