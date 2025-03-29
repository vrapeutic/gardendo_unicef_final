using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleActionAfterWelcomming : MonoBehaviour
{

    [SerializeField]
    GameEvent goToTheWellEvent;
    [SerializeField]
    GameEvent getReadyForWateringEvent;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
    }
    public void OnWelcommingFinish()
    {
        Debug.Log("welcoming finished event listened");
        OnWelcommingFinishRPC();
    }

    public void OnWelcommingFinishRPC()
    {
        Debug.Log("welcoming finished RPC called");
        if (stats.isCompleteCourse)
        {
            goToTheWellEvent.Raise();
            Debug.Log("go to the well event raised");
        }
        else
        {
            getReadyForWateringEvent.Raise();
            Debug.Log("let's water the flower event raised");
        }
    }
}
