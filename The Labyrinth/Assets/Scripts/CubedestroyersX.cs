using UnityEngine;
using System.Collections;

public class CubedestroyersX : MonoBehaviour {

	/* The values below are public because  that way I can customize each individual object with specific
	 speed and distance*/
	public float speed;
	public float distance;
	public float min=2f;
	public float max=3f;

	void Start () {
		min=transform.position.x;//start position
		max=transform.position.x+distance;//end position
	}
	//move the object on the X axis and back to the position fron which it started
	void Update () {
		transform.position = new Vector3(Mathf.PingPong(Time.time*speed,max-min)+min, transform.position.y, transform.position.z);
	}	
}
