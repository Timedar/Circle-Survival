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
    private TextMeshProUGUI tmp; 
    private float ramndomExplosionTime;
    [SerializeField] GameEvent gameOver;
    [SerializeField] GameEvent score;
    [SerializeField] GameEventTransform objectEvent;
    bool isBomb;
    private void Awake() {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        if(this.CompareTag("Bomb"))
        {
            isBomb = true;
            ramndomExplosionTime = 3;
            StartCoroutine(ExplosionCounter(ramndomExplosionTime));
            return;
        }

        var expTime = new Vector2(2,4) * GameManager.instance.BombTimerDificultyCalculating();

        ramndomExplosionTime = Random.Range(expTime.x, expTime.y);

        StartCoroutine(ExplosionCounter(ramndomExplosionTime));
    }

    public void BombClick()
    {
        if(!isBomb)
        {
            score.CallEvnet();
            ParticleSystemManager.instance.SetParticle(ParticleSystemManager.SelectParticle.Point, this.transform.position);
        }
        else
        {
            gameOver.CallEvnet();
            ParticleSystemManager.instance.SetParticle(ParticleSystemManager.SelectParticle.Boom, this.transform.position);
        }
        
        //Zmienic
        objectEvent.CallEvnet(this.transform);
        Destroy(this.gameObject);
    }

    private IEnumerator ExplosionCounter(float time)
    {
        while(time > 0)
        {
            time -= refreshFrequence;

            image.fillAmount = Mathf.InverseLerp(0,ramndomExplosionTime, time);
            tmp.text = Mathf.Ceil(time).ToString();

            yield return new WaitForSeconds(refreshFrequence);
        }
        
        if(!isBomb)
        {
            gameOver.CallEvnet();
            ParticleSystemManager.instance.SetParticle(ParticleSystemManager.SelectParticle.Boom, this.transform.position);
        }

        //Zmienic
        objectEvent.CallEvnet(this.transform);
        Destroy(this.gameObject);
        yield return null;
    }
}
