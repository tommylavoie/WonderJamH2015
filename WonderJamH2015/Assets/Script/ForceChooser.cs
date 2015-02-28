using UnityEngine;
using System.Collections;

public class ForceChooser
{
	public int speed;
	int RIGHT;
	int LEFT;
	int value;
	int direction;
	bool active;

	public ForceChooser(int speed)
	{
		this.speed = speed;
		RIGHT = speed;
		LEFT = (speed*-1);
		active = true;
		value = 50;
		direction = RIGHT;
	}

	public void update()
	{
		if(active)
		{
			if(value > 99)
				direction = LEFT;
			if(value < 1)
				direction = RIGHT;
			value += direction;
		}
	}

	public int getValue()
	{
		return value;
	}

	public int stop()
	{
		active = false;
		return value;
	}
}
