using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Vector3 _cameraOffset;
    private Vector3 _targetPosition;

    private void Start()
    {
        _cameraOffset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        _targetPosition = _player.transform.position + _cameraOffset;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime);
    }
}