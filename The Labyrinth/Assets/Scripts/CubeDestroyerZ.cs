using UnityEngine;
using System.Collections;

public class CubeDestroyerZ : MonoBehaviour {

	/* The values below are public because  that way I can customize each individual object with specific
	 speed and distance*/
	public float speed;
	public float distance;
	public float min=2f;
	public float max=3f;

	void Start () {
		min=transform.position.z;//start position
		max=transform.position.z+distance;//end positio
	}

	//move the object on the Z axis and back to the position fron which it started
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time*speed,max-min)+min);
	}	
}
