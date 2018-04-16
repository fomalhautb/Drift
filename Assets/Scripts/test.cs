using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	public float magnitude;
	void Start () {
		transform.GetComponent<Rigidbody> ().AddForce (Vector2.up * magnitude);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
