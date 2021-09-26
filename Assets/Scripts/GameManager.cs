using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentScore;
    [SerializeField] GameEvent gameOver;
    [SerializeField] GameEvent score;
    [SerializeField] SaveParameters save;
    public static event UnityAction<int> updateScoreEvent = delegate{};
    public static event UnityAction<float> updateTimeEvent = delegate{};
    private Camera camera;
    private float time;
    private void Start()
    {
        camera = Camera.main;
        score.reciveEvent += CountingPoints;
        gameOver.reciveEvent += GameOver;
        InputReader.current.onClickStart += OnClick;
    }

    private void Update() {
        time += Time.deltaTime;
        updateTimeEvent.Invoke(time);
    }

    public void CountingPoints()
    {
        //Update ui and best score SO
        currentScore += 1;
        updateScoreEvent.Invoke(currentScore);
        if(save.bestScore < currentScore)
        {
            save.bestScore = currentScore;
            updateScoreEvent.Invoke(save.bestScore);
        }
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
        Vector2 mousePos = camera.ScreenToWorldPoint(InputReader.current.position);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if(hit)
        {
            var selected = hit.transform.GetComponent<ExplosionCounting>();
            if(selected != null)
                selected.BombClick();
        }
    
    }
    private void OnDestroy() {
        score.reciveEvent -= CountingPoints;
        gameOver.reciveEvent -= GameOver;
        InputReader.current.onClickStart -= OnClick;
    }

}
