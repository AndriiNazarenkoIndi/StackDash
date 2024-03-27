using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _nameMainMenuScene;
    [SerializeField] private string _nameBaseScene;

    public void RestartScene()
    {
        if (!string.IsNullOrEmpty(_nameBaseScene))
        {
            SceneManager.LoadScene(_nameBaseScene);
        }
    }

    public void ReturnToMainMenu()
    {
        if (!string.IsNullOrEmpty(_nameMainMenuScene))
        {
            SceneManager.LoadScene(_nameMainMenuScene);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}