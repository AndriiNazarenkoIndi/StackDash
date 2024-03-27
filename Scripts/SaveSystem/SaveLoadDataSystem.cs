using UnityEngine;

public class SaveLoadDataSystem : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private GameDataToSave _gameData;
    private SaveSystem _saveSystem;

    private string _nameGameDataFile = "GameDataStackDash.sd";
    
    private void Awake()
    {
        _saveSystem = new SaveSystem(_nameGameDataFile);
        _gameData = new GameDataToSave();
        LoadGameData();
    }

    public void SaveGameData()
    {
        _gameData.maxScoreValue = _scoreCounter.MaxScore;
        _saveSystem.Save(_gameData);
    }

    public void LoadGameData()
    {
        _saveSystem.Load(_gameData);
        _scoreCounter.MaxScore = _gameData.maxScoreValue;
    }
}