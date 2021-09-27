using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public int currentScore;
    [SerializeField] SaveParameters saveSO;
    [SerializeField] GameEvent gameOverEvent;
    [SerializeField] GameEvent scoreEvent;
    public static event UnityAction<int> updateScoreEvent = delegate{};
    public static event UnityAction<float> updateTimeEvent = delegate{};
    public static event UnityAction<int> updateBestScoreEvent = delegate{};
    [SerializeField] public AnimationCurve dificultySpawnCurveLvl;
    [SerializeField] public AnimationCurve dificultyBombTimerCurveLvl;
    float timeFromBegin;
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
        instance = this;
    }
    private void Start()
    {
        scoreEvent.reciveEvent += CountingPoints;
        gameOverEvent.reciveEvent += GameOver;
        InputReader.current.onClickStart += OnClick;
    }

    private void Update() {
        timeFromBegin += Time.deltaTime;
        updateTimeEvent.Invoke(timeFromBegin);
    }

    public void CountingPoints()
    {
        //Update ui and best score SO
        currentScore += 1;
        updateScoreEvent.Invoke(currentScore);
        if(saveSO.bestScore < currentScore)
        {
            saveSO.bestScore = currentScore;
            updateBestScoreEvent.Invoke(saveSO.bestScore);
        }
    }

    public float SpawnDificultyCalculating()
    {
        return dificultySpawnCurveLvl.Evaluate(timeFromBegin);
    }
    public float BombTimerDificultyCalculating()
    {
        return dificultyBombTimerCurveLvl.Evaluate(timeFromBegin);
    }

    //Podobne 2 funckje
    public void Pause()
    {
        UIManager.instance.GameOverScrene("PAUSE");
    }
    public void GameOver()
    {
        //Stop game and show ending screen
        UIManager.instance.GameOverScrene("GAME OVER");
        Debug.Log("Boom");
    }


    private void OnClick() {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(InputReader.current.position);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if(hit)
        {
            var selected = hit.transform.GetComponent<ExplosionCounting>();
            if(selected != null)
                selected.BombClick();
        }
        else
        {
            ParticleSystemManager.instance.SetParticle(ParticleSystemManager.SelectParticle.Grass, mousePos);
        }
    
    }
    private void OnDestroy() {
        scoreEvent.reciveEvent -= CountingPoints;
        gameOverEvent.reciveEvent -= GameOver;
        InputReader.current.onClickStart -= OnClick;
    }

}
