using UnityEngine;

public class SpawnPoolObstacleManager : MonoBehaviour
{
    [SerializeField] private Transform _obstaclePoolPosition;
    [SerializeField] private Transform _obstacleSpawnPosition;
    [SerializeField] private ObjectSelector _objectSelector;

    [SerializeField] [Range(0, 100)] private int _obstacleCount = 30;
    [SerializeField] [Range(1.0f, 10.0f)] private float _timeSecToSpawn = 3.0f;

    private Pool<Obstacle> _poolObstacle = new Pool<Obstacle>();
    private Obstacle _obstaclePrefab;
    private Timer _spawnTimer;
    private bool _isSpawning = false;

    private int _randomDigit;

    private void Start()
    {
        InitPool();
        InitSpawnTimer();
    }

    private void InitPool() 
    {
        for (int i = 0; i < _obstacleCount; i++)
        {
            _randomDigit = UnityEngine.Random.Range(0, _objectSelector.ObjectLength);
            _obstaclePrefab = _objectSelector.ObjectSelection(_randomDigit);
            _poolObstacle.CreateObjectInPool(_obstacleCount, _obstaclePrefab, _obstaclePoolPosition);
        }
    }

    private void InitSpawnTimer()
    {
        _spawnTimer = new Timer(_timeSecToSpawn);
        _spawnTimer.SetTime();
    }

    private void Update()
    {
        SpawnObstacleByTiming();
    }

    private void SpawnObstacleByTiming()
    {
        _isSpawning = _spawnTimer.CountdowmInSec();
        if (_isSpawning)
        {
            if (_poolObstacle.FillingThePoolElements > 0)
            {
                Obstacle _spawnedObstacle = _poolObstacle.SpawningAnObjectFromThePool(_obstacleSpawnPosition);
            }
            _spawnTimer.SetTime();
        }
    }

    public void ReturnObstacleToPool(Obstacle _returnedObstacle)
    {
        _poolObstacle.ReturningAnObjectToThePool(_obstaclePoolPosition, _returnedObstacle);
    }
}