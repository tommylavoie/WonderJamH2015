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
	bool active;
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
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(active && !cursorStopped && Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Tommy suce encore plus");
			finalValue = chooser.stop();
			cursorStopped = true;
		}
		if(active && !cursorStopped)
		{
			chooser.update();
			int actualValue = chooser.getValue();
			float newX = bar.transform.position.x - (cursorWidth/2) + (actualValue*cursorWidth/100);
			cursor.transform.position = new Vector2(newX, cursor.transform.position.y);
			Invoke("hide", 2);
		}
		if(!active && Input.GetKeyDown(KeyCode.Space)){
			go();
			Debug.Log ("Tommy suce");
		}
	}
}
