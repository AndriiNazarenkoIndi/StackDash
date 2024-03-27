using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _localScoreText;
    [SerializeField] private TMP_Text _maxTextScoreText;

    [Header("Limit stack")]
    [SerializeField] private LimitStack _limitStack;
    [SerializeField] private TMP_Text _timeToLoseText;

    [Header("Player status")]
    [SerializeField] private PlayerGameStatus _playerGameStatus;
    [SerializeField] private UIPanel _gameOverPanel;

    private void Start()
    {
        StartInit();
        AllSubscribe();
    }

    private void StartInit()
    {
        UpdateScoreText();
        SetTimeToLose();
    }

    #region Event subscribe
    private void AllSubscribe()
    {
        try
        {
            _scoreCounter.scoreUpdataEvent += UpdateScoreText;
            _playerGameStatus.gameOverEvent += GameOverStatus;
            _limitStack.stackStepEvent += UpdateTimeToLoseText;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    private void AllUnsubscribe()
    {
        try
        {
            _scoreCounter.scoreUpdataEvent -= UpdateScoreText;
            _playerGameStatus.gameOverEvent -= GameOverStatus;
            _limitStack.stackStepEvent -= UpdateTimeToLoseText;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
    #endregion

    #region Base function
    private void UpdateText(TMP_Text text, int value)
    {
        text.text = value.ToString();
    }

    private void UpdateText(TMP_Text text, float value)
    {
        text.text = value.ToString();
    }

    private void SetActiveUIElement(GameObject elementUI, bool activeStatus)
    {
        elementUI.SetActive(activeStatus);
    }
    #endregion

    private void UpdateScoreText()
    {
        if (_localScoreText != null)
        {
            _localScoreText.text = _scoreCounter.LocalScore.ToString();
        }
        if (_maxTextScoreText != null)
        {
            _maxTextScoreText.text = _scoreCounter.MaxScore.ToString();
        }
    }

    private void SetTimeToLose()
    {
        UpdateText(_timeToLoseText, _limitStack.CountdownValue);
    }

    private void UpdateTimeToLoseText(bool status)
    {
        SetActiveUIElement(_timeToLoseText.gameObject, status);
        UpdateText(_timeToLoseText, _limitStack.CountdownValue);
    }

    private void GameOverStatus()
    {
        SetActiveUIElement(_gameOverPanel.gameObject, true);
        AllUnsubscribe();
    }

    private void OnDestroy()
    {
        AllUnsubscribe();
    }
}