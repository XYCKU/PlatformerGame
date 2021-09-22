using UnityEngine;

public class CannonAttackSystem : MonoBehaviour, ICannon
{
	[SerializeField] private int _damage;
	[SerializeField] private float _attackDelay;
	public int Damage { get => _damage; }
	public float AttackDelay { get => _attackDelay; }
	public void DoDamage(IDamageable target)
	{
		
	}
}
