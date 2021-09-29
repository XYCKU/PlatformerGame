using UnityEngine;

public class Projectile : MonoBehaviour, IAttacker
{
	private int _damage;
	private Vector2 _velocity;
	private Rigidbody2D _rigidbody2D;
	public int Damage => _damage;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	private void FixedUpdate()
	{
		_rigidbody2D.MovePosition(_rigidbody2D.position + _velocity * Time.fixedDeltaTime);
	}
	public void Setup(int damage, Vector2 velocity)
	{
		_damage = damage;
		_velocity = velocity;
	}
	public void DealDamage(IDamageable target)
	{
		target.TakeDamage(_damage);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		IDamageable target = collision.gameObject.GetComponent<IDamageable>();
		if (target != null) {
			DealDamage(target);
		}
		Destroy(this.gameObject);
	}
}
