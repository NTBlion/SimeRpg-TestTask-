using UnityEngine;

public class PlatformGenerator : ObjectPool
{
    [SerializeField] private GameObject _platformTemplate;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private int _startCount;

    private Vector3 _nextSpawnPosition;
    private Vector3 _lastSpawnPosition;

    private void Start()
    {
        _nextSpawnPosition = transform.position;

        Initialize(_platformTemplate);

        for (int i = 0; i < _startCount; i++)
        {
            if (TryGetObject(out GameObject platform))
            {
                SetChunk(platform);
            }
        }

        _lastSpawnPosition = transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _lastSpawnPosition) > _spawnDistance)
        {
            if (TryGetObject(out GameObject platform))
            {
                SetChunk(platform);
                _lastSpawnPosition = transform.position;
                DisableObjectAboardScreen();
            }
        }
    }

    private void SetChunk(GameObject platform)
    {
        platform.SetActive(true);
        platform.transform.position = _nextSpawnPosition;
        _nextSpawnPosition.z += platform.transform.localScale.z;
    }
}
