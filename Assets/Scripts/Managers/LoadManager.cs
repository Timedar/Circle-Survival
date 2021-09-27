using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadSO", menuName = "ScriptableObjects/LoadSO", order = 1)]
public class LoadManager : ScriptableObject
{
    public void LoadScene(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}
