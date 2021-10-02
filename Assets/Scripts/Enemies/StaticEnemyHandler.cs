using UnityEngine;

public class StaticEnemyHandler : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _attackDelay;
	[SerializeField] private float _projectileVelocity;
	[SerializeField] private GameObject _projectile;
	[SerializeField] private Transform _shootPoint;
	[SerializeField] private GameObject _target;
	private float _attackRadius;
	private float _sqrAttackRadius;
	private float _lastAttackTime;
	private CircleCollider2D _attackTrigger;
	public int Damage => _damage;
	public float AttackDelay => _attackDelay;

	private void Awake()
	{
		_attackTrigger = GetComponent<CircleCollider2D>();
		_sqrAttackRadius = _attackTrigger.radius * _attackTrigger.radius;
	}
	private void Update()
	{
		Attack();
		_lastAttackTime -= Time.deltaTime;
	}
	private void Attack()
	{
		if (_target == null) return;

		float sqrDistance = Utility.sqrDistance(transform.position, _target.transform.position);
		if (sqrDistance <= _sqrAttackRadius && _lastAttackTime <= 0) {
			Shoot(_target);
			_lastAttackTime = _attackDelay;
		}
	}
	public void Shoot(GameObject player)
	{	
		Vector2 direction = (player.transform.position - _shootPoint.transform.position);
		Vector2 velocity = direction.normalized * _projectileVelocity;

		GameObject proj = Instantiate(_projectile, _shootPoint.transform.position, transform.rotation);
		Destroy(proj.gameObject, 5f);

		Quaternion q = Quaternion.FromToRotation(Vector2.up, direction);
		proj.transform.rotation *= q;
		proj.GetComponent<Projectile>().Setup(Damage, velocity);
	}
}
