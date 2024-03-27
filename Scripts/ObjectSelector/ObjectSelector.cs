using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private Obstacle[] _obstacleObjects;

    public int ObjectLength => _obstacleObjects.Length;

    public Obstacle ObjectSelection(int index)
    {
        if (_obstacleObjects.Length > 0)
        {
            return _obstacleObjects[index];
        }
        else
        {
            return null;
        }
    }
}