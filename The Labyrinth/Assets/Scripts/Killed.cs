using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Killed : MonoBehaviour {

	//the values below are public so that they can be specified from the unity program
	public GameObject player;
	public Text loseText;

	void OnCollisionEnter(Collision  other)
	{
		//if player is hit by object with Enemy tag it will be destroyed
		if (other.gameObject.tag == "Enemy") 
		{
			//Destroy player
			Destroy(gameObject);
		}
	}
}
