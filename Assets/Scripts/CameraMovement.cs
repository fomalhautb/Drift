using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject focus;
	public float height;
	public float distance;
	public float lerpSpeed;

	void Start () 
	{
		
	}

	void Update () 
	{
		/*transform.position = focus.transform.position + new Vector3 (0, height, 0) + focus.GetComponent<Rigidbody> ().velocity.normalized * distance;
		transform.LookAt (focus.transform);
		Vector3 camRot = new Vector3 (transform.rotation.eulerAngles.x, Quaternion.LookRotation (focus.GetComponent<Rigidbody> ().velocity).eulerAngles.y, 0);
		camRot = Vector3.Lerp (transform.rotation.eulerAngles, camRot, lerpSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Euler (camRot);*/
		transform.position = focus.transform.position + Vector3.up * height;
		//transform.rotation = Quaternion.Euler (Vector3.zero);
	}
}
