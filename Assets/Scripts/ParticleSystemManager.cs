using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager instance;
    [SerializeField] ParticleSystem BoomParticle;
    [SerializeField] ParticleSystem PointParticle;
    [SerializeField] ParticleSystem GrassParticle;
    public Dictionary<SelectParticle, Queue<ParticleSystem>> particlePool = new Dictionary<SelectParticle, Queue<ParticleSystem>>();
    public enum SelectParticle{
        Boom,
        Point,
        Grass
    } 

    private void Awake() {
        instance = this;
    }
    public void SetParticle(SelectParticle selectedParticle, Vector2 positionOfPlay)
    {
        var particle = PoolParticle(selectedParticle);

        if (particle == null)
        {
            switch (selectedParticle)
            {
                case SelectParticle.Boom:
                    particle = Instantiate(BoomParticle, positionOfPlay, Quaternion.identity, this.transform);
                    break;

                case SelectParticle.Point:
                    particle = Instantiate(PointParticle, positionOfPlay, Quaternion.identity, this.transform);
                break;

                case SelectParticle.Grass:
                    particle = Instantiate(GrassParticle, positionOfPlay, Quaternion.identity, this.transform);
                break;
            }
        }
        else
            particle.gameObject.transform.position = positionOfPlay;
            particle.gameObject.SetActive(true);

        StartCoroutine(DisableParticle(particle, particlePool[selectedParticle], particle.main.duration));
    }

    private ParticleSystem PoolParticle(SelectParticle selected)
    {
        Queue<ParticleSystem> queue;
        if (!particlePool.ContainsKey(selected))
        {
            queue = new Queue<ParticleSystem>();
            particlePool.Add(selected, queue);
        }
        else
            queue = particlePool[selected];
        
        if(queue.Count > 0)
            return queue.Dequeue();
        else
            return null;
    }

    private IEnumerator DisableParticle(ParticleSystem particle, Queue<ParticleSystem> queue, float time)
    {
        yield return new WaitForSeconds(time);
        queue.Enqueue(particle);
        particle.gameObject.SetActive(false);
    }
}
