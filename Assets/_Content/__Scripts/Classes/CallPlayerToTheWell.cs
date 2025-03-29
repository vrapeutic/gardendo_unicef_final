using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPlayerToTheWell : MonoBehaviour
{
    [SerializeField]  bool playerMovedTowardsTheWell;

    WaitForSeconds waitingSeconds = new WaitForSeconds(20);


    void Start()
    {
        playerMovedTowardsTheWell = false;
    }

    public void TimedConditionChecked()
    {
        Debug.Log("Moved");
    }

   

    
}
