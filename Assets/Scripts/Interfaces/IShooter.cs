using System.Collections;
using UnityEngine;
public interface IShooter<T>
{
	void Shoot(T target);
}
