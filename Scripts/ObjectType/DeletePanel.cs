using UnityEngine;

public class DeletePanel : MonoBehaviour
{
    [SerializeField] private SpawnPoolPlatformManager _spawnPoolPlatformManager;
    [SerializeField] private SpawnPoolObstacleManager _spawnPoolObstacleManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Platform platform))
        {
            _spawnPoolPlatformManager.ReturnPlatformToPool(platform);
        }
        else if (collider.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            _spawnPoolObstacleManager.ReturnObstacleToPool(obstacle);
        }
    }
}