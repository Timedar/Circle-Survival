using UnityEngine;

[CreateAssetMenu(fileName = "Save", menuName = "ScriptableObjects/Save", order = 1)]
[System.Serializable]
public class SaveParameters : ScriptableObject
{
    [SerializeField] public int bestScore;


    public void Load() {
        Debug.Log("Load");
        var score = PlayerPrefs.GetInt("Score");
        bestScore = score;
    }

    public void Save() {
        Debug.Log("Save");
        PlayerPrefs.SetInt("Score", bestScore);
        PlayerPrefs.Save();
    }   
}
