public interface IAttacker
{
	public int Damage { get; }
	public float AttackDelay { get; }
	void DoDamage(IDamageable target);
}
