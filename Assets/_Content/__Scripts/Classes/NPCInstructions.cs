using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInstructions : MonoBehaviour
{

    [SerializeField]
    Animator npcAnimator;
    Statistics stats;
    int maxFlowerNumber;
    int flowerIndex;
    private void Start()
    {
        flowerIndex = 1;
        npcAnimator = this.GetComponent<Animator>();
        stats = Statistics.instane;
        maxFlowerNumber = stats.numberOfFlowers;
    }
    public void TellThePlayerToHoldTheBucket()
    {
        TellThePlayerToHoldTheBucketRPC();
    }

    public void OnPlayerGrabbTheBucket()
    {
        OnPlayerGrabbTheBucketRPC();
    }

    public void OnHandleDown()
    {
        OnHandleDownRPC();
    }

    public void ReadyToWaterTheFlower()
    {
        ReadyToWaterTheFlowerRPC();
    }

    public void PlayerPlanntedFlower()
    {
        PlayerPlantedFlowerRPC();
    }

    public void PlayerPlantedAllFlowers()
    {
        PlayerPlantedAllFlowersRPC();
    }

    private void SetAnimationClib(int clibInt)
    {
        npcAnimator.SetInteger("NPCAnimController", clibInt);
    }


    public void TellThePlayerToHoldTheBucketRPC()
    {
        Debug.Log("tell the player to hold the bucket rpc");
        SetAnimationClib(4);//tell the player to hold the bucket
    }

    public void OnPlayerGrabbTheBucketRPC()
    {
        SetAnimationClib(5); //tell the player to grab the handle
        Debug.Log("player grabs the bucket RPC");
    }

    public void OnHandleDownRPC()
    {
        SetAnimationClib(7); // tell the player to fill the bucket to the end;
        Debug.Log("on handle down RPC");
    }

    public void ReadyToWaterTheFlowerRPC()
    {
        SetAnimationClib(9);// let's water the flower
        Debug.Log("player ready to water the flower RPC");
        StartCoroutine(TellThePlayerToLookAtTheFlower());
    }

    public void PlayerPlantedFlowerRPC()
    {
        if (flowerIndex <= (maxFlowerNumber - 1))
        {
            Debug.Log("player planted flower RPC");
            SetAnimationClib(11);// good job you planted a beautiful flower
            flowerIndex++;
        }
    }

    IEnumerator TellThePlayerToLookAtTheFlower()
    {
        yield return new WaitForSeconds(4);
        SetAnimationClib(10);
        Debug.Log("look at the flower RPC");
        //look at the flower
        StartCoroutine(StandOnTheFootSteps());
    }

    IEnumerator StandOnTheFootSteps()
    {
        yield return new WaitForSeconds(7);
        SetAnimationClib(19);
        Debug.Log("stand on the footsteps RPC");
        //stand on the footsteps
    }

    public void PlayerPlantedAllFlowersRPC()
    {
        Debug.Log("player planted all the flower RPC");
        SetAnimationClib(14);//wow you've planted all these beautiful flowers;
    }

    public void WigglePotInstructions()
    {
        SetAnimationClib(20);// Fix the pot
        Debug.Log("wiggle pot fix instructions");
    }

    public void WaveToChildrenInstructions()
    {
        SetAnimationClib(21);// wave to children
        Debug.Log("wave to children instructions");
    }

    public void ShooBirdInstructions()
    {
        SetAnimationClib(22);// shoo bird
        Debug.Log("shoo bird instructions");
    }

    public void StopAnimation()
    {
        SetAnimationClib(0);
    }
}
