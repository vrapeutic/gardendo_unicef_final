using UnityEngine;

public class FinalizeFlowersStates : MonoBehaviour
{

    public static bool tasksAreDone = false;

    [SerializeField] int flowerMaxNumber;
    [SerializeField] int currentIndix;
    AnimatorTrigger animatorTrigger;


    [SerializeField] GameEvent flowerFinishedEvent;
    [SerializeField] GameEvent gameFinishedEvent;
    private int numberOfWateringCycle;

    Statistics stats;

    public static bool stopWateringCoroutine = false;



    void Start()
    {
        animatorTrigger = FindObjectOfType<AnimatorTrigger>();
        tasksAreDone = false;
        currentIndix =0;
        stats = Statistics.instane;
        flowerMaxNumber = stats.numberOfFlowers;

    }

    public void FinalizeCurrentState()
    {
        Debug.Log("Finalize Current State");
        FinalizeCurrentStateRPC();
    }

    public void FinalizeCurrentStateRPC()
    {


        Debug.Log("Finalize Current State RPC");
        if (Statistics.android)
        {
        currentIndix++;

            if (currentIndix >= (flowerMaxNumber ))
            {

                tasksAreDone = true;

                gameFinishedEvent.Raise();


                EndSession.instance.GameOver();
                Debug.Log("FinalFlower");

            }

        }
    }


    public void StopLastFlowerCoroutine(bool _stopFlowerCoroutine)
    {
        stopWateringCoroutine = _stopFlowerCoroutine;
    }

   

    

}
