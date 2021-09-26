using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Canvas HUDCanvas;
    [SerializeField] Canvas gameOverPauseCanvas;
    [SerializeField] TextMeshProUGUI ComunicatTMP;
    [SerializeField] TextMeshProUGUI ScoreTMP;
    [SerializeField] TextMeshProUGUI TimeTMP;
    [SerializeField] TextMeshProUGUI BestScoreTMP;
    
    private void Awake() {
        instance = this;
    }
    private void OnEnable() {
        GameManager.updateScoreEvent += UpdateScore;
        GameManager.updateTimeEvent += UpdateTime;
    }

    private void OnDisable() {
        GameManager.updateScoreEvent -= UpdateScore;
        GameManager.updateTimeEvent -= UpdateTime;
    }
    void UpdateTime(float time)
    {
        TimeTMP.text = $"Time: {Mathf.FloorToInt(time)}";
    }

    void UpdateScore(int score)
    {
        ScoreTMP.text = $"Score: {score}";
    }

    void UpdateBestScore(int bestScore)
    {
        BestScoreTMP.text = $"NEW BEST SCORE {bestScore}!";
    }

    public void GameOverScrene(string state)
    {
        ComunicatTMP.text = state;
        HUDCanvas.enabled = false;
        gameOverPauseCanvas.enabled = true;
    }

}
