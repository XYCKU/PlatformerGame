using UnityEngine;
public interface ICannon
{
	public int ProjectileSpeed { get; }
	public IProjectile Projectile { get; }
}
