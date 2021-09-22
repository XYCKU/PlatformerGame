using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyHandler : MonoBehaviour
{
	private CircleCollider2D _attackTrigger;
	private IAttacker _attacker;
	private IDamageable _damageable;

	private void Awake()
	{
		_attackTrigger = GetComponent<CircleCollider2D>();
		_attacker = GetComponent<CannonAttackSystem>();
		_damageable = GetComponent<DamageSystem>();
	}

}
