using UnityEngine;
using System.Collections;

public class CoinSound : MonoBehaviour {

	//create a field and collect the element from the unity(get the specified sound from the unity program)
	public AudioClip hitSound;

	void Start() 
	{
		AudioSource audio = GetComponent<AudioSource> ();
	}
	/*if the player collide with an object with tag coin the sound specified above will be executed and 
	the object will be destroyed.It is not destroyed in PlayerMovements script because then the sound
	wouldn't play becaus e the coin object is destroyed*/
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Coin") 
		{
			audio.Play();
			Destroy(other.gameObject);
		}
	}
}
