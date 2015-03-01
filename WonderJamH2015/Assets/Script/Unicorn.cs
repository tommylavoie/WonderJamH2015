using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Collections;

public class Unicorn : MonoBehaviour 
{
	int lives = 10;
	bool soundPlayed = false;
	public Sprite heartEmpty;
	GameObject[] hearts;
	// Use this for initialization
	void Start () 
	{
		hearts = GameObject.FindGameObjectsWithTag("Heart");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(lives == 0)
		{
			if(!soundPlayed)
			{
				soundPlayed = true;
				SoundEffectScript.Instance.MakeGame_overSound();
			}
			Map.Instance.setGameOver(true);
		}
	}

	void OnTriggerEnter(Collider collider) 
	{
		if(collider.gameObject.tag.Equals("Enemy"))
		{
			SoundEffectScript.Instance.MakeFillette_ahahahahSound();
			if(lives > 0)
			{
				hearts[10-lives].GetComponent<Image>().overrideSprite = (heartEmpty);
				lives--;
			}
		}
	}

	void OnGUI()
	{
		//GUI.Label(new Rect(10, 10, 100, 20), "Vies: " + lives);
		if(Map.Instance.isGameOver())
		{
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 20), "GAME OVER");
		}
	}
}
