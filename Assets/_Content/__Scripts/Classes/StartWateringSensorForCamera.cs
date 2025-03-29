using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWateringSensorForCamera : MonoBehaviour
{
    [SerializeField] Flower myFlower;
    public bool isPlayerLooking;
    public static int interruptionThreshold = 0;


    private float interruptionCounter;
    private bool isInterrupted;

    private void Start()
    {
        if (!myFlower) myFlower = this.GetComponentInParent<Flower>();
    }
    private void Update()
    {
        if (isInterrupted)
        {
            interruptionCounter += Time.deltaTime;
            if (interruptionCounter >= 3)
            {
                interruptionThreshold++;
                isInterrupted = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Player camera has Entered flower1");
            isPlayerLooking = true;
            interruptionCounter = 0;
            isInterrupted = false;
            myFlower.UpdateLookingState(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("player camera exit flower");
            isInterrupted = true;
            isPlayerLooking = false;
            myFlower.UpdateLookingState(false);
        }
    }

    public void ResetValues()
    {
        isPlayerLooking = false;
        isInterrupted = false;
        interruptionThreshold = 0;
        interruptionCounter = 0;
        // Debug.Log("Reset interruption count = " + interruptionThreshold);
    }
}
