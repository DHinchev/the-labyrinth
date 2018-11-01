using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	//this script is for rotating the coin objects like an  animation non stop
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
