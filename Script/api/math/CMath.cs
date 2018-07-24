using UnityEngine;
using System.Collections;

public class CMath
{
    public const float INFINITY = float.MaxValue;
    public const float MIN_INFINITY = float.MinValue;

	public static int randomIntBetween(int aMin, int aMax)
	{
		return Random.Range (aMin, aMax + 1);
	}

	public static float randomFloatBetween(float aMin, float aMax)
	{
		return Random.Range (aMin, aMax);
	}

	public static float clampDeg(float aDeg)
	{
		aDeg = aDeg % 360.0f;
		if (aDeg < 0.0f) 
		{
			aDeg += 360.0f;
		}

		return aDeg;
	}

	public static bool pointInRect(float aX, float aY, float aRectX, float aRectY, float aRectWidth, float aRectHeight)
	{
		return (aX >= aRectX && aX <= aRectX + aRectWidth && aY >= aRectY && aY <= aRectY + aRectHeight);
	}

	public static float dist(float aX1, float aY1, float aX2, float aY2)
	{
		return Mathf.Sqrt((aX2 - aX1) * (aX2 - aX1) + (aY2 - aY1) * (aY2 - aY1));
	}

	public static float min(float aValue1, float aValue2)
	{
		if (aValue1 < aValue2)
		{
			return aValue1;
		}
		
		return aValue2;
	}
	
	// Convert from radians to degrees.
	public static float radToDeg(float aAngle)
	{
		return aAngle * 180 / Mathf.PI; 
		//TODO: return aAngle * Mathf.Rad2Deg;
	}
	
	// Convert from degrees to radians.
	public static float degToRad(float aAngle)
	{
		return aAngle * Mathf.PI / 180;
		// TODO: Optimizar pi/180.
	}
}
