using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketFillingState : MonoBehaviour
{
  
    bool bucketIsFull = false;
    [SerializeField] GameEvent bucketIsFullEvent;
    [SerializeField] Animator waterLevelAnim;
    [SerializeField] AudioSource waterSFX;

    public void OnBucketIsFull()
    {
        OnBucketIsFullRPC();
    }

    public void OnBucketIsFullRPC()
    {
        bucketIsFullEvent.Raise();
        waterLevelAnim.speed = 0f;
        waterSFX.Stop();
    }
}
