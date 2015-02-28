using UnityEngine;
using System.Collections;

public class Unicorn : MonoBehaviour 
{
	public int lives = 30;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(lives == 0)
		{
			Map.Instance.setGameOver(true);
		}
	}

	void OnTriggerEnter(Collider collider) 
	{
		if(collider.gameObject.tag.Equals("Enemy"))
		{
			lives--;
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Vies: " + lives);
		if(Map.Instance.isGameOver())
		{
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 20), "GAME OVER");
		}
	}
}
