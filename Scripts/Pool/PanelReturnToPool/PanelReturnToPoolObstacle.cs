using UnityEngine;

public class PanelReturnToPoolObstacle : MonoBehaviour
{
    [SerializeField] private SpawnPoolObstacleManager _spawnPoolObstacleManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            _spawnPoolObstacleManager.ReturnObstacleToPool(obstacle);
        }
    }
}