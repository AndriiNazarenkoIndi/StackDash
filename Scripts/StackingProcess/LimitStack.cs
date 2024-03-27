using System.Collections;
using TMPro;
using UnityEngine;
using static LimitStack;

public class LimitStack : MonoBehaviour
{
    [SerializeField] private StackingProcess _stackingProcess;
    [SerializeField] private int _maxStackSize = 12;
    [SerializeField] [Range(0, 5)] private int _numberOfStep = 5;
    [SerializeField] [Range(0, 5)] private int _stepInSeconds = 1;

    private WaitForSeconds _timeDelay;
    private bool _counterInternalLoop = false;
    private bool _excessWasDetected = false;
    private int _countdown;

    public delegate void StackLevelOvershootEvent();
    public event StackLevelOvershootEvent stackLevelOvershootEvent;

    public delegate void StackStepEvent(bool value);
    public event StackStepEvent stackStepEvent;

    public LimitStack()
    {
        _timeDelay = new WaitForSeconds(_stepInSeconds);
    }

    public int MaxStackSize => _maxStackSize;
    public bool ExcessWasDetected => _excessWasDetected;
    public int CountdownValue => _countdown;

    private void Start()
    {
        InitTimer();
        SubscribeToEventExceedingLimit();
    }

    #region Subscribe/Unscribe event limitStackEvent
    private void SubscribeToEventExceedingLimit()
    {
        _stackingProcess.limitStackEvent += TimerToLose;
    }

    private void UnsubscribeToEventExceedingLimit()
    {
        _stackingProcess.limitStackEvent -= TimerToLose;
    }
    #endregion

    private void InitTimer()
    {
        _countdown = _numberOfStep;
    }

    private void TimerToLose()
    {
        StartCoroutine(CountdownToLose());
    }

    private void InversCounterInternalLoop()
    {
        _counterInternalLoop = !_counterInternalLoop;
    }

    private IEnumerator CountdownToLose()
    {
        _excessWasDetected = true;
        InversCounterInternalLoop();
        while (_counterInternalLoop)
        {
            _countdown--;
            stackStepEvent?.Invoke(_excessWasDetected);
            yield return _timeDelay;
            if (_countdown <= 0)
            {
                InversCounterInternalLoop();
                OverageCheck();
            }
        }
    }

    private void OverageCheck()
    {
        if (StackingProcess._stackCount >= _maxStackSize)
        {
            stackLevelOvershootEvent?.Invoke();
            UnsubscribeToEventExceedingLimit();
        }
        else
        {
            _excessWasDetected = false;
            _countdown = _numberOfStep;
            stackStepEvent?.Invoke(_excessWasDetected);
        }
    }

    private void OnDestroy()
    {
        UnsubscribeToEventExceedingLimit();
    }
}