using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesLifeTimeController : MonoBehaviour
{
    ParticleSystem.MainModule particleComponent;
    float distance;
    WaitForSeconds updateTimeStep = new WaitForSeconds(0.5f);
   // public float coff;
    [SerializeField] GameObject wellWateringTip;
    [SerializeField] GameObject waterSurfaceInTheBucket;


    private void Start()
    {
        particleComponent = this.GetComponent<ParticleSystem>().main;
        StartCoroutine(UpdateLifeTime());
    }

    public void ParticlesLifeTimeRPC()
    {
        particleComponent.startLifetime = 0.2f + (0.5f * distance);
    }

    private void GetDistance()
    {
        distance = wellWateringTip.transform.position.y - waterSurfaceInTheBucket.transform.position.y;
    }

    IEnumerator  UpdateLifeTime()
    {
        while (true)
        {
            yield return updateTimeStep;
            GetDistance();
        }
     
    }
}
