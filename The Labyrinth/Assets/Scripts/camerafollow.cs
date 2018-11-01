using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camerafollow : MonoBehaviour {
	/* This script is mainly for the camera to follow the player object throughout the map.Some of the
	 values below are public because I have to specify for which object they are referring in the unity program
	 */
	public GameObject player;
	public Vector3 offset;
	public Text loseText;
	public Text time;
	public float timeRun;
	private float minutes;
	private float seconds;
	private float fraction;
	public Canvas quickMenu;
	public Button startText;
	public Button exitText;

	// start viewing the 
	void Start () {
		offset = transform.position - player.transform.position;
		quickMenu = quickMenu.GetComponent<Canvas> ();
		quickMenu.enabled = false;
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeRun-= Time.deltaTime;
		minutes = timeRun / 60;
		seconds=timeRun % 60;
		fraction=(timeRun * 100) % 100;

		//format the timer in the game(how to display the time)
		time.text=string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

		//if the time hit zero-game over
		 if(timeRun==0.000000)
		{
			Destroy (player);
			loseText.text = "Game Over!";
			quickMenu.enabled = true;
		}
		//if the player is not destroyed, the camera keep viewing it.
		if (player != null) {
			transform.position = player.transform.position + offset;
		}

		else 
		{
			Destroy (player);
			loseText.text = "Game Over!";
			quickMenu.enabled = true;
		}
		
	}

	public void GameExit()
	{
		Application.LoadLevel ("UI");
	}

	public void StartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
