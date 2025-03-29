using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager instance = new StatisticsManager();

    Statistics stats;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        stats = Statistics.instane;
    }

    private void Update()
    {
        if (stats.wateringResponseTimeCounterBegin)
        {
            stats.wateringResponseTimeCounter += Time.deltaTime;
            // if (stats.wateringResponseTimeCounter % 1 < 0.02) //Debug.Log("Response Time : Watering Respone Timer Counter: " + stats.wateringResponseTimeCounter);
        }
        if (stats.birdFlyingResponseTimeCounterBegin)
        {
            stats.birdFlyingResponseTimeCounter += Time.deltaTime;
            //if (stats.birdFlyingResponseTimeCounter % 1 < 0.02) //Debug.Log("Response Time : Bird Respone Timer Counter: " + stats.birdFlyingResponseTimeCounter);
        }
    }

    public void ResetStatistics()
    {
        ResetStatisticsRPC();
    }

    public void ResetStatisticsRPC()
    {

        stats.flowerSustained = 0f;
        stats.wellSustained = 0f;
        stats.totalFlowerGrowth = 0;
        stats.growthSpeed = 0f;
        stats.level = 1;

        stats.tasksWithLimitiedInterruptions = 0;
        stats.totalNumberOfTasks = 4;
        stats.wateringResponseTimeCounter = 0;
        stats.wateringResponseTimeCounterBegin = false;
        stats.birdFlyingResponseTimeCounter = 0;
        stats.birdFlyingResponseTimeCounterBegin = false;
        stats.birdFlyingResponseTimes = 0;
        stats.wateringResponseTimes = 0;
    }

    public void WateringResponseTimeController(bool _wateringResponseTimeCounterBegin)
    {
        stats.wateringResponseTimeCounterBegin = _wateringResponseTimeCounterBegin;
    }
}
