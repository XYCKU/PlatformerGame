using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletShooter : MonoBehaviour, IShooter<Player>
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _projectileVelocity;
    [SerializeField] private GameObject _pfProjectile;

    private List<Player> _targets = new List<Player>();
    private bool _isShooting;

    public void Shoot(Player target)
    {
        Vector2 shootPointPosition = _shootPoint.position;
        Vector2 direction = (((Vector2)target.transform.position - shootPointPosition)).normalized;
        Vector2 velocity = direction * _projectileVelocity;

        GameObject proj = Instantiate(_pfProjectile, shootPointPosition, transform.rotation);

        Quaternion q = Quaternion.FromToRotation(Vector2.up, direction);
        proj.transform.rotation = q;
        proj.GetComponent<Projectile>().Setup(_damage, velocity);
        
        Destroy(proj.gameObject, 5f);
    }

    private IEnumerator ShootCoroutine()
    {
        while (_targets.Count > 0)
        {
            Shoot(_targets.First());
            yield return new WaitForSeconds(_shootDelay);
        }

        _isShooting = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player ply = other.gameObject.GetComponent<Player>();
        if (ply == null) return;

        _targets.Add(ply);
        
        if (!_isShooting)
        {
            _isShooting = true;
            StartCoroutine(ShootCoroutine());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Player ply = other.gameObject.GetComponent<Player>();
        if (ply == null) return;
        _targets.Remove(ply);
    }
}
