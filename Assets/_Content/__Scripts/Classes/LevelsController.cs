﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField] GameObject butterfly;
    [SerializeField] GameObject bird;
    private static float timer = 0f;
    public static float blockingTimer = 0f;
    [SerializeField] public float timeBetweenDistractors = 30f;
    [SerializeField] GameObject level4Distractor; //9 levels, 1-3 no distractors, 6 distractors total for levels 4,5,6,7,8,9
    [SerializeField] GameObject level5Distractor;
    [SerializeField] GameObject level6Distractor;
    [SerializeField] GameObject[] level7Distractor;
    [SerializeField] GameObject level8Distractor;
    [SerializeField] GameObject level9Distractor;
    [SerializeField] AudioSource[] secondLevelDistractorsAudioSources;
    [SerializeField] GameEvent WigglePotGameEvent;
    [SerializeField] GameEvent WaveToChildrenGameEvent;
    [SerializeField] GameEvent ShooBirdGameEvent;

    public static bool isWaitingForInteraction = false;
    public static bool isBlockingInteraction = false;
    public static bool isReadyForWatering = false;
    public static bool isGameOver = false;
    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
        if (stats.isVisualOnly) {
            foreach (AudioSource audioSource in secondLevelDistractorsAudioSources) {
                audioSource.enabled = false;
            }
        }

        if (stats.level == 9)
        {
            level9Distractor.SetActive(true);
        }

        DisableAllDistractors();
        WavingSensorController.areChildrenWaving = false;
        ResetPotController.isPotKnockedOver = false;
        isWaitingForInteraction = false;
        isReadyForWatering = false;
        timer = 0;
        //if (stats.level == 1)
        //{
        //    DisableLevel_2Distractor();
        //}
        //else

        //if (stats.level >= 4)
        //{
        //    if (Statistics.android)
        //        EnableLevelDistractors();
        //}

    }

    private void Update()
    {
        if (isReadyForWatering && !isGameOver) //only start distractors when npc is done with welcoming/or filling bucket to start distractors
        {
            timer += Time.deltaTime;

            if (isBlockingInteraction)
                blockingTimer += Time.deltaTime;

            if (timer >= timeBetweenDistractors && !isWaitingForInteraction)
            {
                timer = 0f;
                DisableAllDistractors();
                EnableRandomDistractor();
            }
        }
    }

    private void DisableAllDistractors()
    {
        level4Distractor.SetActive(false);
        level5Distractor.SetActive(false);
        level6Distractor.SetActive(false);
        //level7Distractor.SetActive(false);
        DisableAlllevel7Distractors();
        level8Distractor.SetActive(false);
        //level9Distractor.SetActive(false);
        level9Distractor.GetComponent<BoxCollider>().enabled = false;
    }

    private void EnableRandomDistractor()
    {
        switch (stats.level)
        {
            case 1:
            case 2:
            case 3:
                break;
            case 4:
                Enablelevel4Distractors();
                break;
            case 5:
                Enablelevel5Distractors();
                break;
            case 6:
                Enablelevel6Distractors();
                break;
            case 7:
                Enablelevel7Distractors();
                break;
            case 8:
                Enablelevel8Distractors();
                break;
            case 9:
                Enablelevel9Distractors();
                break;
            default:
                break;
        }
    }

    private void Enablelevel4Distractors()
    {
        level4Distractor.SetActive(true);
    }

    private void Enablelevel5Distractors()
    {
        int randomDistractorIndex = Random.Range(1, 3);

        switch (randomDistractorIndex)
        {
            case 1:
                level4Distractor.SetActive(true);
                break;
            case 2:
                level5Distractor.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Enablelevel6Distractors()
    {
        int randomDistractorIndex = Random.Range(1, 4);

        switch (randomDistractorIndex)
        {
            case 1:
                level4Distractor.SetActive(true);
                break;
            case 2:
                level5Distractor.SetActive(true);
                break;
            case 3:
                level6Distractor.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Enablelevel7Distractors()
    {
        EnableLevel7Distractor();
        isWaitingForInteraction = true;
    }

    private void Enablelevel8Distractors()
    {
        int randomDistractorIndex = Random.Range(1, 3);

        switch (randomDistractorIndex)
        {
            case 1:
                EnableLevel7Distractor();
                break;
            case 2:
                Enablelevel8Distractor();
                break;
            default:
                break;
        }

        isWaitingForInteraction = true;
    }

    private void Enablelevel9Distractors()
    {
        int randomDistractorIndex = Random.Range(1, 4);

        switch (randomDistractorIndex)
        {
            case 1:
                EnableLevel7Distractor();
                break;
            case 2:
                Enablelevel8Distractor();
                break;
            case 3:
                Enablelevel9Distractor();
                break;
            default:
                break;
        }

        isWaitingForInteraction = true;
    }

    public void DisableLevel_2Distractor()
    {
        butterfly.SetActive(false);
    }

    public void EnableLevel_3Distractor()
    {
        bird.SetActive(true);
    }
    public void EnableLevel_3DistractorRPC()
    {
        bird.SetActive(true);
    }

    public static void DidInteracttWithDistractor()
    {
        timer = 0;
        isWaitingForInteraction = false;
        blockingTimer = 0;
        isBlockingInteraction = false;
    }

    public void EnableLevel7Distractor()
    {
        level7Distractor[Statistics.instane.currentFlowerIndex].gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
        level7Distractor[Statistics.instane.currentFlowerIndex].GetComponent<Animator>().enabled = true;
        level7Distractor[Statistics.instane.currentFlowerIndex].GetComponent<Animator>().SetTrigger("WigglePot");
        level7Distractor[Statistics.instane.currentFlowerIndex].GetComponent<AudioSource>().Play();
        WigglePotGameEvent.Raise();
        Debug.Log("7");
    }

    public void DisableAlllevel7Distractors()
    {
        foreach (GameObject gameObject in level7Distractor)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    public void Enablelevel8Distractor()
    {
        level8Distractor.SetActive(true);
        WaveToChildrenGameEvent.Raise();
    }

    public void Enablelevel9Distractor()
    {
        level9Distractor.GetComponent<BoxCollider>().enabled = true;
        ShooBirdGameEvent.Raise();
    }

    public void StartDistractions()
    {
        isReadyForWatering = true;
    }

    public void StopDistractions()
    {
        DisableAllDistractors();
        isGameOver = true;
    }
}
