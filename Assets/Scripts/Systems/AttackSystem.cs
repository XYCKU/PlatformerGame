using UnityEngine;

public class AttackSystem : MonoBehaviour, IAttacker
{
	[SerializeField] private int _damage;
	
	public delegate void AttackEvent();
	public event AttackEvent OnAttack;
	public int Damage => _damage;

	public AttackSystem(int damage)
	{
		_damage = damage;
	}
	public void DealDamage(IDamageable target)
	{
		target.TakeDamage(Damage);
		OnAttack?.Invoke();
	}
}
