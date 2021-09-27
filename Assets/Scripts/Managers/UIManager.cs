using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] SaveParameters BestScoreSource;
    [SerializeField] Canvas HUDCanvas;
    [SerializeField] Canvas gameOverPauseCanvas;
    [SerializeField] TextMeshProUGUI ComunicatTMP;
    [SerializeField] TextMeshProUGUI ScoreTMP;
    [SerializeField] TextMeshProUGUI TimeTMP;
    [SerializeField] TextMeshProUGUI BestScoreTMP;
    [SerializeField] TextMeshProUGUI TimeTMPPause;
    [SerializeField] TextMeshProUGUI ScoreTMPPause;
    [SerializeField] TextMeshProUGUI BestScoreTMPPause;
    [SerializeField] Button resumeButton;
    
    private void Awake() {
        instance = this;
    }
    private void OnEnable() {
        GameManager.updateScoreEvent += UpdateScore;
        GameManager.updateTimeEvent += UpdateTime;
        GameManager.updateBestScoreEvent += UpdateBestScore;
    }

    private void OnDisable() {
        GameManager.updateScoreEvent -= UpdateScore;
        GameManager.updateTimeEvent -= UpdateTime;
        GameManager.updateBestScoreEvent -= UpdateBestScore;
    }
    void UpdateTime(float time)
    {
        TimeTMP.text = $"Time: {Mathf.FloorToInt(time)}";
    }

    void UpdateScore(int score)
    {
        ScoreTMP.GetComponent<Animator>().SetTrigger("ChangeNum");
        ScoreTMP.text = score.ToString();
        ScoreTMPPause.text = score.ToString();
    }

    void UpdateBestScore()
    {
        BestScoreTMP.transform.parent.gameObject.SetActive(true);
        BestScoreTMP.text = BestScoreSource.bestScore.ToString();
    }

    public void Resume()
    {
        HUDCanvas.enabled = true;
        gameOverPauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void GameoverScreen(string state)
    {
        ComunicatTMP.text = state;
        HUDCanvas.enabled = false;
        gameOverPauseCanvas.enabled = true;

        resumeButton.gameObject.SetActive(false);

        TimeTMPPause.text = TimeTMP.text;
        BestScoreTMPPause.text = BestScoreSource.bestScore.ToString();
    }

    public void PauseScreen(string state)
    {
        Time.timeScale = 0;
        ComunicatTMP.text = state;
        HUDCanvas.enabled = false;
        gameOverPauseCanvas.enabled = true;

        resumeButton.gameObject.SetActive(true);

        TimeTMPPause.text = TimeTMP.text;
        BestScoreTMPPause.text = BestScoreSource.bestScore.ToString();
    }

    private void OnDestroy() {
        Time.timeScale = 1;
    }
}
