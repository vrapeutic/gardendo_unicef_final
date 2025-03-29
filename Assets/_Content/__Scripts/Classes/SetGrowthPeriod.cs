using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGrowthPeriod : MonoBehaviour
{

    private float eachFlowerGrowthPeriod;
    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
    }

    public void SetFlowerGrowthPeriod(int _totalSceneSeconds)
    {
        SetFlowerGrowthPeriodRPC(_totalSceneSeconds);
    }

    public void SetFlowerGrowthPeriodRPC(int _totalSceneSeconds)
    {
        stats.totalFlowerGrowth = _totalSceneSeconds;
        eachFlowerGrowthPeriod = (float)stats.totalFlowerGrowth / 4f;
        stats.growthSpeed = 0.5f; //(float)eachFlowerGrowthPeriod / 10f;
        Debug.Log("totalSceneSeconds:  " + stats.totalFlowerGrowth);
        Debug.Log("Growth Speed: " + stats.growthSpeed);
    }
}
