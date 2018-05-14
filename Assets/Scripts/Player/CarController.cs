using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CarController : NetworkBehaviour
{
	public float acceleration;
	public AnimationCurve accelerationDrag;
	public float backAcceleration;
	public AnimationCurve torque;
	public float rotateDrag;
	public GameObject[] tires;
	public float phoneRotateRate = 2;

	private Vector3 playerPos;  
	private Quaternion playerRot;  
	private float playerSpeed;  

	void Start ()
	{
		if (isLocalPlayer)
		{
			Camera.main.GetComponent<CameraMovement> ().focus = transform.gameObject;
			transform.tag = "Player";
			Input.gyro.enabled = true;
			Input.gyro.updateInterval = 0.01f;
		} else
		{
			transform.tag = "OtherPlayer";
		}
	}

	void FixedUpdate ()
	{
		if (isLocalPlayer)
		{
			MoveCar ();
			ComputeCarPhysic ();
			CmdSendServerPos (transform.position, transform.rotation, GetComponent<Rigidbody> ().velocity.magnitude, GetComponent<NetworkIdentity>().GetInstanceID());
		} else
		{
			LerpPosition ();
		} 
		MoveTire ();
	}

	float InputY ()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetMouseButton(0))
			{
				if (Input.mousePosition.x < Screen.width / 2)
				{
					return -1;
				} else
				{
					return 1;
				}
			}
			return 0;

		} else
		{
			return Input.GetAxisRaw ("Vertical");
		}
	}

	float InputX ()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			return Mathf.Max(Mathf.Min(Input.gyro.gravity.x * phoneRotateRate, 1), -1);
		} else
		{
			return Input.GetAxisRaw ("Horizontal");
		}
		
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

	void MoveTire()
	{
		for(int i=0; i < 4; i++)
		{
			if (i < 2)
			{
				tires [i].transform.rotation = Quaternion.Euler(transform.up * (transform.eulerAngles.y + InputX() * 30));
			}
		}
	}

	[Command]
	public void CmdSendServerPos(Vector3 pos, Quaternion rot, float speed, int id)  
	{  
		playerPos = pos;  
		playerRot = rot;  
		playerSpeed = speed;
		RpcSycPos (pos, rot, speed, id);
	}

	[ClientRpc]
	public void RpcSycPos(Vector3 pos, Quaternion rot, float speed, int id)
	{
		if (id != GetComponent<NetworkIdentity> ().GetInstanceID())
		{
			playerPos = pos;  
			playerRot = rot;  
			playerSpeed = speed;
		}
	}


}