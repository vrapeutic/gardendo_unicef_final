using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public static bool isBirdOnFlower;
    [SerializeField] Animator bird;
    [SerializeField] Animator birdParent;

    Statistics stats;
    private void Start()
    {
        isBirdOnFlower = false;
        stats = Statistics.instane;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            Debug.Log("Bird On Flower!");
            stats.birdFlyingResponseTimeCounterBegin = true;
            isBirdOnFlower = true;
            IdleBirdAnim();
            LevelsController.isBlockingInteraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bird"))
        {
            stats.birdFlyingResponseTimeCounterBegin = false;
        }
    }

    private void IdleBirdAnim()
    {
        if (Statistics.android) {
            IdleBirdAnimRPC();
        }
    }

    public void IdleBirdAnimRPC()
    {
        birdParent.SetFloat("speed", 0.0f);
        bird.SetInteger("BirdAnimation", 1);
    }

}
