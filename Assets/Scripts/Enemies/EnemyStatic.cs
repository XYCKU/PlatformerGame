using UnityEngine;

public class EnemyStatic : MonoBehaviour
{
    private IShooter<Player> _enemyShooter;
    private Rigidbody2D _rigidbody2D;
    private bool _facingLeft;

    private void Awake()
    {
        _enemyShooter = GetComponent<IShooter<Player>>();
    }
}