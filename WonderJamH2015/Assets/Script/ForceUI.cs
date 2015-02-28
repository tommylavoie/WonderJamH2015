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

	// Use this for initialization
	void Start () 
	{
		hide ();
		finalValue = -1;
		cursorStopped = true;
		chooser = new ForceChooser(speed);
		cursorWidth = ((RectTransform)bar.GetComponent<RectTransform>()).sizeDelta.x;
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
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Map.Instance.isStarted() && !delay && !Map.Instance.isGameOver())
		{
			if(active && !cursorStopped && !pressed && Input.GetAxis("Jump") > 0)
			{
				finalValue = chooser.stop();
				cursorStopped = true;
				tireTour script = joueur.GetComponent<tireTour>();
				if(Map.Instance.isWaveStarted())
					script.tireItem(finalValue);
				else
					script.tireProjectile(finalValue);
				delay = true;
				Invoke("stopDelay", 5);
			}
			if(active && !cursorStopped)
			{
				chooser.update();
				int actualValue = chooser.getValue();
				float newX = bar.transform.position.x - (cursorWidth/2) + (actualValue*cursorWidth/100);
				cursor.transform.position = new Vector2(newX, cursor.transform.position.y);
				Invoke("hide", 2);
			}
			if(!active && Input.GetAxis("Jump") > 0){
				go();
				pressed = true;
			}
			if(Input.GetAxis("Jump") == 0)
				pressed = false;
		}
	}
}
