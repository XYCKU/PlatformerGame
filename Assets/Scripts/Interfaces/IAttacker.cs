public interface IAttacker
{
	public int Damage { get; }
	void DoDamage(IDamageable target, int damage);
}
