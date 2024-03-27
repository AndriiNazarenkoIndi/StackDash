using UnityEngine;

public class Platform : MonoBehaviour
{
    private float _basePlatformSpeed = 0.0f;
    private const float _zeroSpeed = 0.0f;
    private const float _speedUp = 3.0f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            if (this.gameObject.TryGetComponent(out ObjectMovement objectMovement))
            {
                objectMovement.CurrentSpeedMovement = _zeroSpeed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (this.gameObject.TryGetComponent(out ObjectMovement objectMovement))
            {
                RemovingPlatformFromTheStack(objectMovement);
            }
        }
    }

    private void RemovingPlatformFromTheStack(ObjectMovement objectMovement)
    {
        this.gameObject.transform.SetParent(null);
        StackingProcess._stackCount--;
        _basePlatformSpeed = objectMovement.BaseSpeedMovement;
        objectMovement.CurrentSpeedMovement = _basePlatformSpeed + _speedUp;
    }
}