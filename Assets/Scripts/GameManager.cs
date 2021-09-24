using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int currentScore;
    [SerializeField] GameEvent gameOver;
    [SerializeField] GameEvent score;
    [SerializeField] SaveParameters save;
    private void Start()
    {
        score.reciveEvent += CountingPoints;
        gameOver.reciveEvent += GameOver;
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
    }


}
