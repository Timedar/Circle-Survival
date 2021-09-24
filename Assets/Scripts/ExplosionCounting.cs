using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ExplosionCounting : MonoBehaviour
{
    [SerializeField] float refreshFrequence;

    [SerializeField] Image image;
    private TextMeshProUGUI _tmp; 
    private float _ramndomExplosionTime;
    [SerializeField] GameEvent gameOver;
    [SerializeField] GameEvent score;
    bool isBomb;
    private void Awake() {
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        // _image = GetComponentInChildren<Image>();
    }
    private void Start()
    {
        if(this.CompareTag("Bomb"))
            isBomb = true;

        _ramndomExplosionTime = Random.Range(2,5);
        StartCoroutine(ExplosionCounter(_ramndomExplosionTime));
    }

    public void BombClick()
    {
        if(!isBomb)
            score.CallEvnet();
        else
            gameOver.CallEvnet();
        
        //Zmienic
        Destroy(this.gameObject);
    }

    private IEnumerator ExplosionCounter(float time)
    {
        while(time > 0)
        {
            time -= refreshFrequence;

            image.fillAmount = Mathf.InverseLerp(0,_ramndomExplosionTime, time);
            _tmp.text = Mathf.Ceil(time).ToString();

            yield return new WaitForSeconds(refreshFrequence);
        }
        
        if(!isBomb)
            gameOver.CallEvnet();

        //Zmienic
        Destroy(this.gameObject);
        yield return null;
    }
}
