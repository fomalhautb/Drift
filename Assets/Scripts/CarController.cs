using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

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
		MoveCar ();
		ComputeCarPhysic ();
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
		} 
		else if (InputY () < 0)
		{
			GetComponent<Rigidbody> ().velocity += -transform.forward * backAcceleration * Time.fixedDeltaTime;
		}
		GetComponent<Rigidbody> ().AddTorque (InputX() * (Vector3.up * torque.Evaluate(GetComponent<Rigidbody> ().velocity.magnitude) * Time.fixedDeltaTime));
	}

	void ComputeCarPhysic ()
	{
		GetComponent<Rigidbody> ().velocity *= (float)(1 - accelerationDrag.Evaluate(GetComponent<Rigidbody> ().velocity.x) * Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().angularVelocity *= (float)(1 - rotateDrag * Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().MovePosition (new Vector3 (transform.position.x, 0, transform.position.z));
		GetComponent<Rigidbody> ().MoveRotation (Quaternion.Euler(new Vector3 (0, transform.rotation.eulerAngles.y, 0)));
	}
}