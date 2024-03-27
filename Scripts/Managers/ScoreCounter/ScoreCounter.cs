using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private StackingProcess _stackingProcess;

    public delegate void ScoreUpdataEvent();
    public event ScoreUpdataEvent scoreUpdataEvent;

    private int _localScore;
    private int _maxScore;

    public int LocalScore
    {
        set { _localScore = value; }
        get { return _localScore; }
    }

    public int MaxScore
    {
        set { _maxScore = value; }
        get { return _maxScore; }
    }

    private void Start()
    {
        EventSubscribe();
    }

    private void EventSubscribe()
    {
        try
        {
            _stackingProcess.platformTriggerEvent += AddPointToScore;
        }
        catch (Exception ex)
        {
            Debug.Log("Subscribe in stackingProcess is failed. Error: " + ex);
        }
    }

    public void AddPointToScore(int point)
    {
        _localScore += point;
        MaxScoreUpdate();
        scoreUpdataEvent?.Invoke();
    }

    private void OnDestroy()
    {
        try
        {
            _stackingProcess.platformTriggerEvent -= AddPointToScore;
        }
        catch (Exception ex)
        {
            Debug.Log("Unsubscribe in stackingProcess is failed. Error: " + ex);
        }
    }

    private void MaxScoreUpdate()
    {
        if (_localScore > _maxScore)
        {
            _maxScore = _localScore;
        }
    }
}