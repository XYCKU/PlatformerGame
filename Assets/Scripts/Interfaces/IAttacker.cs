public interface IAttacker
{
	public int Damage { get; }
	void DealDamage(IDamageable target);
}
