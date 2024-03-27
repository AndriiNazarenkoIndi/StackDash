using UnityEngine;

public class ScoreProvider : MonoBehaviour
{
    [SerializeField] [Range(0, 200)] private int _scoreValue = 30;
    
    public int ScoreValue => _scoreValue;
}