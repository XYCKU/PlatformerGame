using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamageable
{
	[SerializeField] private int _health;
	[SerializeField] private int _maxHealth;

	public delegate void HealthEvent();
	public HealthEvent OnDeath;
	public HealthEvent OnDamage;
	public HealthEvent OnHeal;

	public int Health
	{
		get => _health;
		set
		{
			Debug.Log(value + " " + _health);
			if (value > _health) {
				OnDamage?.Invoke();
			} else {
				OnHeal?.Invoke();
			}
			_health = Mathf.Clamp(value, 0, _maxHealth);
			if (_health == 0) {
				OnDeath?.Invoke();
			}
		}
	}
	public int MaxHealth => _maxHealth;
	public float HealthRatio => (float)_health / _maxHealth;

	public void TakeDamage(int damage)
	{
		Health -= damage;
	}
	public void TakeDamage(IAttacker attacker)
	{
		Health -= attacker.Damage;
	}
	public void Heal(int healAmount)
	{
		Health += healAmount;
	}
}
