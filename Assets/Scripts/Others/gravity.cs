using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {

	public GameObject[] others;
	public float mass;

	public float G = 1f;
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 forceSum = Vector3.zero;
		foreach (GameObject other in others)
		{
			float otherMass = other.GetComponent<gravity> ().mass;
			Vector3 vecD = other.transform.position - transform.position;
			float force = G * otherMass * mass / vecD.magnitude;
			forceSum += vecD.normalized * force;
		}
		transform.GetComponent<Rigidbody> ().AddForce (forceSum * Time.fixedDeltaTime);
	}
}
