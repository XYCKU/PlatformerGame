using System;
using UnityEngine;
public class DamageSystem : MonoBehaviour, IDamageable
{
	public delegate void EventDelegate();
	public event EventDelegate OnDamage;
	public event EventDelegate OnDeath;
	public event EventDelegate OnHeal;
	public event EventDelegate OnHealthChange;

	[SerializeField] private int _maxHealth;
	[SerializeField] private int _currentHealth;
	public int Health { get => _currentHealth; }
	public int MaxHealth { get => _maxHealth; }
	public float HealthRatio { get => (float)_currentHealth / _maxHealth; }
	public void TakeDamage(int damage)
	{
		_currentHealth -= damage;
		OnDamage?.Invoke();
		OnHealthChange?.Invoke();
		if (_currentHealth <= 0) {
			_currentHealth = 0;
			OnDeath?.Invoke();
		}
	}
	public void TakeDamage(IAttacker attacker)
	{
		TakeDamage(attacker.Damage);
	}
	public void Heal(int heal)
	{
		_currentHealth += heal;
		if (_currentHealth > _maxHealth) {
			_currentHealth = _maxHealth;
		}
		OnHealthChange?.Invoke();
		OnHeal?.Invoke();
	}
}
