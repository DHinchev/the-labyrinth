using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

	/* This script is for how the UI interface will behave*/
	public Canvas quickMenu;
	public Button startText;
	public Button exitText;
	
	void Start () 
	{
		quickMenu = quickMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quickMenu.enabled = false;
	}

	//if the exit button is pressed make the quick menu visible abd disable the play and exit buttons
	public void ExitPress()
	{
		quickMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;;
	}

	//if the exit is not pressed the star and exit buttons are enabled and the quick menu is invisible
	public void NoPress()
	{
		quickMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;;
	}

	//start playing the first level
	public void StartLevel()
	{
		Application.LoadLevel("1stLevel");
	}

	//is the yes button in the quick menu is pressed exit the application
	public void GameExit()
	{
		Application.Quit ();
	}
}
