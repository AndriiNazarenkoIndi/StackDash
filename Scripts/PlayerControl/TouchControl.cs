using System;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private Transform _parentStack;
    [SerializeField] [Range(0.1f, 20.0f)] private float _speedPlatform = 5.0f;
    [SerializeField] [Range(0.0f, 5.0f)] private float _maxDistance = 2.0f;

    private Touch _touch;
    private Vector3 _target;
    private Vector3 _changePosition;
    private float _valueDirectionX;

    private void Update()
    {
        InputProcess();
    }

    private void InputProcess()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                _valueDirectionX = _touch.deltaPosition.x;
                _valueDirectionX = NormalizedDirectionValue(_valueDirectionX);
                MovementProcess();
            }
        }
    }

    private void MovementProcess()
    {
        _target.x = Mathf.Clamp(_target.x + _valueDirectionX, -_maxDistance, _maxDistance);
        SetChangePosition();
        _parentStack.position = _changePosition;
    }

    private void SetChangePosition()
    {
        _changePosition.x = Mathf.Lerp(_parentStack.position.x, _target.x, _speedPlatform * Time.deltaTime);
        _changePosition.y = _parentStack.position.y;
        _changePosition.z = _parentStack.position.z;
    }

    private float NormalizedDirectionValue(float valueDirection)
    {
        float _minValue = 0.0f;
        float _maxValue = 1.0f;
        float normalizedValue = Mathf.Clamp((valueDirection - _minValue) / (_maxValue - _minValue) * 2 - 1, -1, 1);
        return normalizedValue;
    }
}