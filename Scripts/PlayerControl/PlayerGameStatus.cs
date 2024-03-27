using UnityEngine;

public class PlayerGameStatus : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StackingProcess _stackingProcess;
    [SerializeField] private LimitStack _limitStack;

    public delegate void GameOverEvent();
    public event GameOverEvent gameOverEvent;

    private void Start()
    {
        _limitStack.stackLevelOvershootEvent += OnGameOver;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (StackingProcess._stackCount < 1)
            {
                OnGameOver();
            }
        }
    }

    private void OnGameOver()
    {
        _player.gameObject.SetActive(false);
        gameOverEvent?.Invoke();
    }

    private void OnDestroy()
    {
        _limitStack.stackLevelOvershootEvent -= OnGameOver;
    }
}