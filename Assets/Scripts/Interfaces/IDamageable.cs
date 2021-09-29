public interface IDamageable
{
	public int Health { get; set; }
	public int MaxHealth { get; }
	public float HealthRatio { get; }
	void TakeDamage(int damage);
	void TakeDamage(IAttacker attacker);
	void Heal(int healAmount);
}
