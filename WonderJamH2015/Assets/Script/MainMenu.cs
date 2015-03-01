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
		if(Input.GetAxis("Fire1") > 0)
		{
			Map.Instance.restartInstance();
			Application.LoadLevel("Main");
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(Screen.width/2-50, Screen.height/8, 400, 40), "Le jeu sans nom");
		if(GUI.Button (new Rect(Screen.width/2-40, Screen.height/2, 80, 40), "Jouer"))
		{
			Application.LoadLevel("Main");
		}
	}
}
