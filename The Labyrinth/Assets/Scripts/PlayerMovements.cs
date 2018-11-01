using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovements : MonoBehaviour {
	
	public float speed=15.0f;
	public float drag=2.0f;
	public float terminalRotationalSpeed=25.0f;
	public Vector3 MoveVector {set;get;} 
	private Rigidbody rgbody;
	public Joystick joystick;
	private int count;
	public Text countText;
	public Text winText;
	public Text loseText;
	public GameObject[] coins;
	public GameObject player;

	 void Start()
	{
		rgbody=gameObject.AddComponent<Rigidbody>();
		rgbody.maxAngularVelocity = terminalRotationalSpeed;
		rgbody.drag = drag;
		count = 0;
		SetCountText ();
	}

	//check this methods constantly in case of change
	private void Update()
	{
		MoveVector = PoolInput ();
		Move ();

		//if the player object falls(like bounce from a wall or the ground) he loses and is returned to the main menu
		if (player.transform.position.y <= -3)
		{
			Destroy (player);
			loseText.text = "Game Over!";
			Application.LoadLevel("UI");
		}
		//enable the back key on android device
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel("UI"); 
	}

	//add certain force to move the object depending on the speed specified in the unity program and the 
	//possition of the joystick
	private void Move()
	{
		rgbody.AddForce((MoveVector*speed));
	}
	
	private Vector3 PoolInput()
	{
		Vector3 dir = Vector3.zero;	
		dir.x = joystick.Horizontal ();
		dir.z = joystick.Vertical ();
		if (dir.magnitude > 1)
			dir.Normalize ();
		return dir;
	}

	/*if the player touches an object with coin tag the coin is collected snd rendered invisible
	(the object is not destroyed)*/
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Coin"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText ();
		}
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

	}
	
	//display the number of coins left to collect on the map
	void SetCountText ()
	{
		coins = GameObject.FindGameObjectsWithTag("Coin");
		int decrement = (coins.Length+1) - 1;
		countText.text = "Coins left: " + decrement;
		
		if (decrement == 0)
		{	
			winText.text = "You Win!";
			ExecuteAfterTime(3);
			Application.LoadLevel("NextLevel");
		}
	}
}
