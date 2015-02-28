using UnityEngine;
using System.Collections;

public class ForceChooser
{
	int value;
	int direction;
	bool active;

	public ForceChooser()
	{
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

	public static int LEFT = -1;
	public static int RIGHT = 1;
}
