using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    [SerializeField] SaveParameters bestScoreSO;
    [SerializeField] TextMeshProUGUI bestScoreTMP;
    private void Awake() {
        bestScoreSO.Load();
    }
    
    private void Start() {
        bestScoreTMP.text = bestScoreSO.bestScore.ToString();
    }
}
