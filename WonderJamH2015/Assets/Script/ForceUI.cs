using UnityEngine;
using System.Collections;

public class ForceUI : MonoBehaviour 
{
	public GameObject bar;
	public GameObject cursor;
	public int speed = 4;
	ForceChooser chooser;
	float cursorWidth;
	bool cursorStopped;
	int finalValue;
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
		chooser = new ForceChooser(speed);
		finalValue = -1;
		cursorStopped = false;
	}

	public void show()
	{
		bar.SetActive(true);
		cursor.SetActive(true);
	}

	public void hide()
	{
		bar.SetActive(false);
		cursor.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!cursorStopped && Input.GetKeyDown(KeyCode.Space))
		{
			finalValue = chooser.stop();
			cursorStopped = true;
		}
		if(!cursorStopped)
		{
			chooser.update();
			int actualValue = chooser.getValue();
			float newX = bar.transform.position.x - (cursorWidth/2) + (actualValue*cursorWidth/100);
			cursor.transform.position = new Vector2(newX, cursor.transform.position.y);
		}
	}
}
