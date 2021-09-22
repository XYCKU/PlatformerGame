using UnityEngine;

public class AttackSystem : MonoBehaviour, IAttacker
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDelay;
	public int Damage { get => _damage; }
	public float AttackDelay { get => _attackDelay; }
	public void DoDamage(IDamageable target)
	{
		target.TakeDamage(_damage);
	}
}
