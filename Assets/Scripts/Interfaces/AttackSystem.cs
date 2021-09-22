using UnityEngine;

public class AttackSystem : MonoBehaviour, IAttacker
{
    [SerializeField] private int _damage;

	public int Damage { get => _damage; }
	public void DoDamage(IDamageable target, int damage)
	{
		target.TakeDamage(damage);
	}
}
