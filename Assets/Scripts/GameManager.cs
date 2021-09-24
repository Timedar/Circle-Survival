using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentScore;
    [SerializeField] GameEvent gameOver;
    [SerializeField] GameEvent score;
    [SerializeField] SaveParameters save;
    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
        score.reciveEvent += CountingPoints;
        gameOver.reciveEvent += GameOver;
        InputReader.current.onClickStart += OnClick;
    }

    public void CountingPoints()
    {
        //Update ui and best score SO
        currentScore += 1;
        if(save.bestScore < currentScore)
            save.bestScore = currentScore;
    }

    public void GameOver()
    {
        //Stop game and show ending screen
        Debug.Log("Boom");
    }

    private void OnDestroy() {
        score.reciveEvent -= CountingPoints;
        gameOver.reciveEvent -= GameOver;
        InputReader.current.onClickStart -= OnClick;
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

}
