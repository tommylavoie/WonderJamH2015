using UnityEngine;
using System.Collections;

public class ForceUI : MonoBehaviour 
{
	public GameObject bar;
	public GameObject cursor;
	public int speed = 4;
	public GameObject joueur;
	ForceChooser chooser;
	float cursorWidth;
	bool cursorStopped;
	bool active;
	int finalValue;
	bool delay = false;
	bool pressed = false;
	bool pressedTableFlip = false;
	Animator anim;
	int sound = 0;

	// Use this for initialization
	void Start () 
	{
		hide ();
		finalValue = -1;
		cursorStopped = true;
		chooser = new ForceChooser(speed);
		cursorWidth = ((RectTransform)bar.GetComponent<RectTransform>()).sizeDelta.x;
		anim = joueur.GetComponent<Animator>();
	}

	public void go()
	{
		show ();
		chooser = new ForceChooser(speed);
		finalValue = -1;
		cursorStopped = false;
	}

	public void show()
	{
		active = true;
		bar.SetActive(true);
		cursor.SetActive(true);
	}

	public void hide()
	{
		active = false;
		bar.SetActive(false);
		cursor.SetActive(false);
	}

	void stopDelay()
	{
		delay = false;
	}

	void playSound()
	{
		if(sound == 0)
			SoundEffectScript.Instance.MakeGrowl_1Sound();
		else if(sound == 1)
			SoundEffectScript.Instance.MakeGrowl_2Sound();
		else if(sound == 2)
			SoundEffectScript.Instance.MakeGrowl_3Sound();
		else
			SoundEffectScript.Instance.MakeGrowl_4Sound();
		sound++;
		if(sound >= 4)
			sound = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Map.Instance.isStarted() && !delay && !Map.Instance.isGameOver())
		{
			if(active && !cursorStopped && !pressed && Input.GetAxis("Jump") > 0 && Input.GetAxis("Fire2") == 0 && !pressedTableFlip)
			{
				finalValue = chooser.stop();
				cursorStopped = true;
				tirer();
			}

			if(active && !cursorStopped && !pressed && Input.GetAxis("Jump") > 0 && Input.GetAxis("Fire2") == 0 && pressedTableFlip)
			{
				finalValue = chooser.stop();
				cursorStopped = true;
				flipTable();
			}

			if(active && !cursorStopped)
			{
				chooser.update();
				int actualValue = chooser.getValue();
				float newX = bar.transform.position.x - (cursorWidth/2) + (actualValue*cursorWidth/100);
				cursor.transform.position = new Vector2(newX, cursor.transform.position.y);
				Invoke("hide", 2);
			}
			if(!active && Input.GetAxis("Jump") > 0 && Input.GetAxis("Fire2") == 0){
				go();
				pressed = true;
			}
			if(Input.GetAxis("Jump") == 0)
				pressed = false;

			if(Input.GetAxis ("Fire3") > 0)
			{
				pressedTableFlip = true;
				go ();
			}
		}
	}

	void tirer()
	{
		tireTour script = joueur.GetComponent<tireTour>();
		int time = 2;
		if(Map.Instance.isWaveStarted()){
			script.tireItem(finalValue);
			anim.SetTrigger("TireBanane");
			playSound();
			SoundEffectScript.Instance.MakeBanana_foompSound();
		}
		else{
			time = 5;
			script.tireProjectile(finalValue);
			anim.SetTrigger("TireTour");
			playSound();
			SoundEffectScript.Instance.Maketower_fwiiiinSound();
		}
		delay = true;
		Invoke("stopDelay", time);
	}

	void flipTable()
	{
		tireTour script = joueur.GetComponent<tireTour>();
		script.flipTable(finalValue);
		playSound ();
		playSound ();
		playSound();
		playSound();
		Map.Instance.setGameOver(true);
	}
}
