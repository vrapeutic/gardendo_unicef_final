using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivationState : MonoBehaviour
{
    public void ActivationState(int _state)
    {
        ActivationStateRPC(_state);
    }

    public void ActivationStateRPC(int _state)
    {
             if(_state == 1) gameObject.SetActive(true);
        else if(_state == 0) gameObject.SetActive(false);
    }
}
