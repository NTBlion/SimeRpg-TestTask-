using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _delayBeforeSpawn;
    [SerializeField] private Transform _spawnPoint;

    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _delayBeforeSpawn)
        {
            Instantiate(_enemyTemplate, _spawnPoint.position, Quaternion.identity);
            _time = 0;
        }
    }
}
