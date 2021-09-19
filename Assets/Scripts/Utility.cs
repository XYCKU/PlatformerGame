using UnityEngine;
public static class Utility
{
    public static float sqrDistance(Vector2 first, Vector2 second)
	{
		float x = (first.x - second.x) * (first.x - second.x);
		float y = (first.y - second.y) * (first.y - second.y);
		return x + y;
	}
	public static float xDistance(Vector2 first, Vector2 second)
	{
		return first.x - second.x;
	}
	public static float yDistance(Vector2 first, Vector2 second)
	{
		return first.y - second.y;
	}
}
