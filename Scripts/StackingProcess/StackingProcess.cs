using UnityEngine;

public class StackingProcess : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _jumpHight = 0.3f;
    [SerializeField] private float _objectHight = 0.3f;
    [SerializeField] private LimitStack _limitStack;

    public delegate void PlatformTriggerEvent(int point);
    public event PlatformTriggerEvent platformTriggerEvent;

    public delegate void LimitStackEvent();
    public event LimitStackEvent limitStackEvent;

    public static int _stackCount;

    private Vector3 _newPosition;
    private Vector3 _localPosition;
    private Transform _localTransform;
    private bool _stackCountMax = false;

    public bool StackCountMax => _stackCountMax;

    public StackingProcess() 
    {
        _stackCount = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Stackable stackable))
        {
            SetNewStackElement(collider);
            if (collider.gameObject.TryGetComponent(out ScoreProvider scoreProvider))
            {
                platformTriggerEvent?.Invoke(scoreProvider.ScoreValue);
            }

            if (_stackCount >= _limitStack.MaxStackSize && !_limitStack.ExcessWasDetected)
            {
                _stackCountMax = true;
                limitStackEvent?.Invoke();
            }
        }
    }

    private void SetNewStackElement(Collider collider)
    {
        _newPosition = _player.position;
        _newPosition.y += _jumpHight;
        _player.position = _newPosition;
        _localTransform = collider.transform;
        _localTransform.SetParent(this.transform);
        _localTransform.localPosition = SetPosition();
        _stackCount++;
    }

    private Vector3 SetPosition()
    {
        _localPosition.x = 0;
        _localPosition.y = _stackCount * _objectHight;
        _localPosition.z = 0;
        return _localPosition;
    }
}