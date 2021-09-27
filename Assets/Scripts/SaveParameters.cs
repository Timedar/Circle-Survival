using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Save", menuName = "ScriptableObjects/Save", order = 1)]
[System.Serializable]
public class SaveParameters : ScriptableObject
{
    [SerializeField] public int bestScore;

    private void Awake() {
        bestScore = PlayerPrefs.GetInt("Score",0);
    }
    private void OnDestroy() {
        PlayerPrefs.SetInt("Score", bestScore);
        PlayerPrefs.Save();
    }
}
