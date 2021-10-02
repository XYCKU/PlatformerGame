using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MortairShooter : MonoBehaviour, IShooter<Player>
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _minVerticalDistance;
    [SerializeField] private int _damage;
    [SerializeField] private Transform _shootPoint;
    //[SerializeField] private float _projectileVelocity;
    [SerializeField] private GameObject _pfProjectile;

    private List<Player> _targets = new List<Player>();
    private bool _isShooting;
    public void Shoot(Player target)
    {
        float horizontalDistance = target.transform.position.x - _shootPoint.position.x;
        float verticalDistance = target.transform.position.y - _shootPoint.position.y;
        Vector2 force = new Vector2(horizontalDistance, Mathf.Abs(verticalDistance));

        GameObject proj = Instantiate(_pfProjectile, _shootPoint.position, transform.rotation);

        proj.GetComponent<MortairProjectile>().Setup(_damage, force);
        
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