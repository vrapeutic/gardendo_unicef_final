using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGoesToWell : MonoBehaviour
{
    [SerializeField]
    Animator npcAnimator;
    [SerializeField]
    Animator npcChildAnimator;
    [SerializeField]
    GameEvent npcArrivedToTheWellEvent;
    [SerializeField]
    GameEvent readyToWaterEvent;
    private void Start()
    {
        if (!npcAnimator) npcAnimator = this.GetComponent<Animator>();
        if (!npcChildAnimator) npcChildAnimator = this.GetComponentInChildren<Animator>();
    }
    public void NPCMovesToTheWell()
    {
        if(Statistics.android)
        {
            Debug.Log("npc moves to the well ");
            NPCMovesToTheWellRPC();
        }
       
    }

    public void NPCArrivedToTheWell()
    {
        Debug.Log("npc arrived to the well");
        NPCArrivedToTheWellRPC();
    }

    public void GetNPCBackToHisPosition()
    {
        if(Statistics.android)
        {
            Debug.Log("get npc back to his position");
            GetNPCBackToHisPositionRPC();
        }
       
    }
    public void NPC_ArrivedToOriginalPosition()
    {
        if(Statistics.android)
        {
            Debug.Log("npc arrived to original position");
            NPC_ArrivedToOriginalPositionRPC();
        }
       
    }

    IEnumerator GetReadyWaterFlowers()
    {
        yield return new WaitForSeconds(2);
        readyToWaterEvent.Raise();
    }

    public void NPCArrivedToTheWellRPC()
    {
        Debug.Log("npc arrived to the well RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 0); //stop walking animation and back to idle

        StartCoroutine(NPCArrived());
    }

    IEnumerator NPCArrived()
    {
        yield return new WaitForSeconds(2);
        npcArrivedToTheWellEvent.Raise();
    }

    public void GetNPCBackToHisPositionRPC()
    {
        Debug.Log("get npc back to his position RPC");
        npcAnimator.SetInteger("NPCAnimController", 1);
        npcChildAnimator.SetInteger("NPCAnimController", 16);
    }
    public void NPC_ArrivedToOriginalPositionRPC()
    {
        Debug.Log("npc arrived to original position RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 0); //stop walking animation and back to idle
        npcAnimator.SetInteger("NPCAnimController", 0);
        // readyToWaterEvent.Raise();
        StartCoroutine(GetReadyWaterFlowers());
    }

    public void NPCMovesToTheWellRPC()
    {
        Debug.Log("NPC moves to the well RPC");
        npcChildAnimator.SetInteger("NPCAnimController", 16); // npc waving 
        npcAnimator.SetInteger("CenterToWell",1);  //npc move to the well animation

        Debug.Log("player called to the well");
    }

    public void StopMovement()
    {
        npcAnimator.SetInteger("CenterToWell", 0);  //npc move to the well animation
    }
}
