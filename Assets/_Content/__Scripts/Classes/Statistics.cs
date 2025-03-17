﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public static bool android = false;

    public static int languageIndex=1;// 1 --> vietnamese, 2 --> English, 3 --> arabic

    public int character;// 1 --> Hussien, 2 --> Reem

    public float flowerSustained;
    public float wellSustained;
    public int totalFlowerGrowth = 40;
    public int level = 1;
    public float growthSpeed;
    public bool firstEnterMainMenu = false;
    public bool isGardenEnviroment;
    public bool isCompleteCourse = true;
    public int numberOfFlowers = 4;
    public int instructionNumber = 0;
    public bool isVisualOnly = false;

    public float tasksWithLimitiedInterruptions = 0;
    public float totalNumberOfTasks;

    public int currentFlowerIndex = 0;

    public float wateringResponseTimeCounter;
    public float wateringResponseTimes;
    public bool wateringResponseTimeCounterBegin;

    public float birdFlyingResponseTimeCounter;
    public bool birdFlyingResponseTimeCounterBegin;
    public int birdFlyingResponseTimes;

    //public float flowerWateringTime = 0;
    //public float flowerInteruptionTime;

    public static Statistics instane;
    private void Awake()
    {
        if (instane == null)
        {
            instane = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

#if UNITY_ANDROID
        android = true;
#endif

#if UNITY_STANDALONE
        android = false;
#endif
    }

    public void UpdateCurrentFlowerIndex()
    {
        currentFlowerIndex++;
    }

}
