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
    private void Awake() {
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        // _image = GetComponentInChildren<Image>();
    }
    private void Start()
    {
        _ramndomExplosionTime = Random.Range(2,5);
        StartCoroutine(ExplosionCounter(_ramndomExplosionTime));
    }

    public void BombClick()
    {
        if(this.CompareTag("Point"))
            score.CallEvnet();
        else
            gameOver.CallEvnet();
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

        gameOver.CallEvnet();

        //Zmienic
        Destroy(this.gameObject);
        yield return null;
    }
}
