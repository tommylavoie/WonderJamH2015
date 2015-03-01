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
	System.Random random;

	public ForceChooser(int speed)
	{
		random = new System.Random();
		this.speed = speed;
		RIGHT = speed;
		LEFT = (speed*-1);
		active = true;
		value = random.Next(0,100);
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
