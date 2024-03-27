using UnityEngine;

public class PanelPlatformReturnToPool : MonoBehaviour
{
    [SerializeField] private SpawnPoolPlatformManager _spawnPoolPlatformManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Platform platform))
        {
            if (platform.gameObject.TryGetComponent(out ObjectMovement objectMovement))
            {
                objectMovement.CurrentSpeedMovement = objectMovement.BaseSpeedMovement;
            }
            _spawnPoolPlatformManager.ReturnPlatformToPool(platform);
        }
    }
}