using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAttack : MonoBehaviour, IAttacker
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private int _damage;
    private bool _isAttacking;
    public int Damage => _damage;
    private List<IDamageable> _targets = new List<IDamageable>();

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(Damage);
    }

    private IEnumerator AttackCoroutine()
    {
        while (_targets.Count > 0)
        {
            foreach (IDamageable target in _targets)
            {
                DealDamage(target);
            }

            yield return new WaitForSeconds(_attackDelay);
        }

        _isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player ply = other.gameObject.GetComponent<Player>();
        if (ply == null) return;
        _targets.Add(ply.DamageSystem);
        if (!_isAttacking)
        {
            _isAttacking = true;
            StartCoroutine(AttackCoroutine());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Player ply = other.gameObject.GetComponent<Player>();
        if (ply == null) return;
        _targets.Remove(ply.DamageSystem);
    }
}
