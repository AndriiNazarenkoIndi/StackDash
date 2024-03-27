using UnityEngine;

public class Timer
{
    private float _amountOfTimeInSeconds;
    private float _currentTime;

    public Timer(float amountOfTimeInSeconds)
    {
        _amountOfTimeInSeconds = amountOfTimeInSeconds;
    }

    public void SetTime()
    {
        _currentTime = Time.time + _amountOfTimeInSeconds;
    }

    public bool CountdowmInSec()
    {
        if (Time.time > _currentTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}