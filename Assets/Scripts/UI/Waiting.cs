using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiting : MonoBehaviour 
{
	public float rotateSpeed;
	void Update () 
	{
		transform.Rotate (new Vector3 (0, 0, rotateSpeed * Time.deltaTime));
	}
}
