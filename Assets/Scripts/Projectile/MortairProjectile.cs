using UnityEngine;

public class MortairProjectile : MonoBehaviour, IAttacker
{
	private int _damage;
	private Rigidbody2D _rigidbody2D;
	private Vector2 _force;
	public int Damage => _damage;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.velocity = _force;
		Destroy(gameObject, 5f);
	}
	public void Setup(int damage, Vector2 force)
	{
		_damage = damage;
		_force = force;
	}
	public void DealDamage(IDamageable target)
	{
		target.TakeDamage(_damage);
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		IDamageable target = other.gameObject.GetComponent<IDamageable>();
		if (target == null) return;
		DealDamage(target);
		Destroy(gameObject);
	}
}
