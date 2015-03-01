using UnityEngine;
using System.Collections;

public class vueTactic : MonoBehaviour {
	Vector3 pos;
	bool started = false;
	int step = 4;
	bool invoked = false;

	// Use this for initialization
	void Start () {
		pos = this.gameObject.transform.position;
		pos.x = -28.4f;
		pos.y = 1.6f;
		pos.z = 26.4f;
		this.gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
		this.gameObject.transform.position = pos;
	}

	void addStep()
	{
		step++;
		invoked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(started)
		{
			if (Input.GetAxis("Fire2") > 0) {
				pos.x = 0f;
				pos.y = 50.3f;
				pos.z = 14.4f;
				this.gameObject.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
				this.gameObject.transform.position = pos;
			}
			else {
				pos.x = 0f;
				pos.y = 13.49f;
				pos.z = -28.65f;
				this.gameObject.transform.rotation = Quaternion.AngleAxis(22, Vector3.right);
				this.gameObject.transform.position = pos;	

			}
		}
		else
		{
			if(step == 1)
			{
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(12.4f, 10f, -20f), 10 * Time.deltaTime);
				this.gameObject.transform.Rotate(0.2f,-1f,0);
				if(!invoked)
				{
					Invoke ("addStep", 2);
					invoked = true;
				}
			}
			if(step == 2)
			{
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(22.4f, 10f, -20f), 10 * Time.deltaTime);
				this.gameObject.transform.Rotate(-0.2f,1f,0);
				if(!invoked)
				{
					Invoke ("addStep", 3);
					invoked = true;
				}
			}
			if(step == 3)
			{
				transform.position = Vector3.MoveTowards (transform.position, new Vector3(0f, 13.49f, -28.65f), 10 * Time.deltaTime);
				this.gameObject.transform.Rotate(0.12f,0.8f,0);
				if(!invoked)
				{
					Invoke ("addStep", 2.31f);
					invoked = true;
				}
			}
			if(step == 4)
			{
				pos.x = 0f;
				pos.y = 13.49f;
				pos.z = -28.65f;
				this.gameObject.transform.rotation = Quaternion.AngleAxis(22, Vector3.right);
				this.gameObject.transform.position = pos;
				started = true;
				Map.Instance.setStarted(true);
			}
		}
	}
}
