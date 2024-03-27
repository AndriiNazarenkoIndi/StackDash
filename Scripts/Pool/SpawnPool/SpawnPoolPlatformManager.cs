using UnityEngine;

public class SpawnPoolPlatformManager : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private Transform _platformPoolPosition;
    [SerializeField] private Transform _platformSpawnPosition;

    [SerializeField][Range(0, 100)] private int _platformCount = 30;
    [SerializeField][Range(1.0f, 10.0f)] private float _timeSecToSpawn = 3.0f;

    private Pool<Platform> _poolPlatform = new Pool<Platform>();
    private Timer _spawnTimer;
    private bool _isSpawning = false;

    private void Start()
    {
        InitSpawnTimer();
        InitPool();
    }

    private void InitPool()
    {
        _poolPlatform.CreatePool(_platformCount, _platformPrefab, _platformPoolPosition);
    }

    private void InitSpawnTimer()
    {
        _spawnTimer = new Timer(_timeSecToSpawn);
        _spawnTimer.SetTime();
    }

    private void Update()
    {
        SpawnPlatformByTiming();
    }

    private void SpawnPlatformByTiming()
    {
        _isSpawning = _spawnTimer.CountdowmInSec();
        if (_isSpawning)
        {
            if (_poolPlatform.FillingThePoolElements > 0)
            {
                Platform _spawnedPlatform = _poolPlatform.SpawningAnObjectFromThePool(_platformSpawnPosition);
            }
            _spawnTimer.SetTime();
        }
    }

    public void ReturnPlatformToPool(Platform returnedPlatform)
    {
        _poolPlatform.ReturningAnObjectToThePool(_platformPoolPosition, returnedPlatform);
    }
}