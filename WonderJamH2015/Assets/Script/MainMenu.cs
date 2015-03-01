using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void play()
	{
		Application.LoadLevel("Main");
	}

	public void goToCredit()
	{
		Application.LoadLevel("Credit");
	}

	public void goToTutorial()
	{
		Application.LoadLevel("Tutoriel");
	}

	public void exitGame()
	{
		Application.Quit();
	}
}
