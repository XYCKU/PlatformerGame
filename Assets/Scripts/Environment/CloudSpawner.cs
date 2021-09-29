using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour, ISpawner
{
	[SerializeField] private CircleCollider2D _collider;
	[SerializeField] private float _spawnDelay;
	[SerializeField] private float _cloudSpeed;
	[SerializeField, Range(0f, 1f)] private float _spawnRareRatio;
	[SerializeField] private Vector2 _direction;
	[SerializeField] private Transform _removePosition;
	[SerializeField] private GameObject _pfCloud;

	[SerializeField] private List<Sprite> _spawnable;
	[SerializeField] private List<Sprite> _spawnableRare;

	private SpriteRenderer _spriteRenderer;
	private float _spawnRadius;

	private void Awake()
	{
		_spawnRadius = _collider.radius;
		_spriteRenderer = _pfCloud.GetComponent<SpriteRenderer>();
	}
	private void Start()
	{
		StartCoroutine(Spawn());
	}
	public IEnumerator Spawn()
	{
		while (true) {
			_spriteRenderer.sprite = GetRandomSprite();
			GameObject newCloud = Instantiate(_pfCloud, GetRandomPoint(), Quaternion.identity);
			Cloud cloud = newCloud.GetComponent<Cloud>();
			cloud.SetValues(_direction, _removePosition.position, _cloudSpeed);
			yield return new WaitForSeconds(_spawnDelay);
		}
	}
	private Sprite GetRandomSprite()
	{
		if (_spawnRareRatio > 0f && Random.value <= _spawnRareRatio) {
			return GetRandomFromList(_spawnableRare);
		}
		return GetRandomFromList(_spawnable);
	}
	private Vector2 GetRandomPoint()
	{
		return (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
	}
	private T GetRandomFromList<T>(List<T> list)
	{
		var random = new System.Random();
		return list[random.Next(0, list.Count)];
	}
	
}
