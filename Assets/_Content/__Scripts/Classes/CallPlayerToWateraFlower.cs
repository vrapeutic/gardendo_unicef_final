using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPlayerToWateraFlower : MonoBehaviour
{

    WaitForSeconds waitingSeconds = new WaitForSeconds(20);
    bool wateringState = false;
    public static bool isPlayerWateringTheFlower = false;

    private void Start()
    {
        Debug.Log("Call player to water a flower is started");
    }

    public void OnConditionNotChecked()
    {
        LetsWaterTheFlowerRPC();
    }

    public void LetsWaterTheFlowerRPC()
    {
        SetAnimatorInt.instance.AnimatorSetIntger(9);
    }

    public void PlayerWateringTheFlowerState(bool _isPlayerWateringTheFlower)
    {
        isPlayerWateringTheFlower = _isPlayerWateringTheFlower;
    }

    IEnumerator PlayerWateringTheFlowerStateIEnum(bool _isPlayerWateringTheFlower)
    {
        yield return new WaitForSeconds(.2f);
        isPlayerWateringTheFlower = _isPlayerWateringTheFlower;
    }



}
