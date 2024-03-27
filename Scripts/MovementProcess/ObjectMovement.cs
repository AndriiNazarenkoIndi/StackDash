using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 30.0f)] private float _baseSpeedMovement = 6.0f;

    private Vector3 _movementDirection = new Vector3(0, 0, -1);
    private float _currentSpeed = 0.0f;

    public float CurrentSpeedMovement
    {
        get { return _currentSpeed; }
        set { _currentSpeed = value; }
    }

    public float BaseSpeedMovement
    {
        get { return _baseSpeedMovement; }
        set { _baseSpeedMovement = value; }
    }

    private void Start()
    {
        _currentSpeed = _baseSpeedMovement;
    }

    private void Update()
    {
        MovingProcess();
    }

    private void MovingProcess()
    {
        transform.Translate(_movementDirection * _currentSpeed * Time.deltaTime);
    }
}