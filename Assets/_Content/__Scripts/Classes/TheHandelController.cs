using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHandelController : MonoBehaviour
{
   
   
    [SerializeField] Animator handelAnim;
    
    [SerializeField] GameEvent HandleDownEvent;

    public static bool isHandleDown;

    Outline MyOutLine;
    private void Start()
    {
        isHandleDown = false;
        MyOutLine = this.gameObject.GetComponent<Outline>();
        if (!Statistics.instane.isCompleteCourse) {
            MyOutLine.enabled = false;

            this.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Handel Ainem");
            MyOutLine.enabled = false;
            PlayHandleAnimRPC();
        }
    }

    public void PlayHandleAnimRPC()
    {
        if (!isHandleDown)
        {
            handelAnim.SetInteger("HndleControl", 1);
            HandleDownEvent.Raise();
            isHandleDown = true;
            MyOutLine.enabled = false;
            StopOutline();
        }
        else
        {
            handelAnim.SetInteger("HndleControl", 2);
            this.GetComponent<Collider>().enabled = false;
            isHandleDown = false;
        }
       
    }

    
   public void OnHandleOpen()
    {
        isHandleDown = true;
    }
    
    public void StartOutline()
    {
        MyOutLine.enabled = true;
    }

    private void StopOutline()
    {
        MyOutLine.enabled = false;
    }
}
