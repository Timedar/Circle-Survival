using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadSO", menuName = "ScriptableObjects/LoadSO", order = 1)]
public class LoadManager : ScriptableObject
{
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void MainManu()
    {
        SceneManager.LoadScene(0);
    }
}
