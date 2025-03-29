using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] instruction;

    Statistics stats;
    void Start()
    {
        stats = Statistics.instane;
        stats.currentFlowerIndex = 0;
    }

    public void ShowInstructionsUI(int _number)
    {
        if (_number != stats.instructionNumber)
        {
            instruction[(_number - 1)].SetActive(true);
        }
        else
        {
            instruction[(_number - 1)].SetActive(false);
        }
    }

    public void DisableInstructionsUI(GameObject instructionsToShow)
    {
        for (int i = 0; i < instruction.Length; i++)
        {
            instruction[i].SetActive(false);
        }
    }

    public void setLanguage(int languageNO)
    {
        Statistics.languageIndex = languageNO;
    }

    public void SetFlowerGrowthPeriod(int totalSceneSeconds)
    {
        stats.totalFlowerGrowth = totalSceneSeconds;
        float eachFlowerGrowthPeriod = (float)stats.totalFlowerGrowth / 4f;
        stats.growthSpeed = 0.5f; //(float)eachFlowerGrowthPeriod / 10f;
    }

    public void SetCurrentFlowerIndeex(int flowerIndex)
    {
        stats.currentFlowerIndex = 0;
    }

    public void ChangeMenue(GameObject MenueToAppear)
    {
        MenueToAppear.SetActive(true);
        gameObject.SetActive(false);
    }

    public void LoadScene()
    {
        LoadSceneRPC();
    }
    public void SetCompleteCourse(bool isCompleteCourse)
    {
        SetCompleteCourseRPC(isCompleteCourse);
        Debug.Log("set course ");
    }
    public void SetCompleteCourseRPC(bool isCompleteCourse)
    {
        Debug.Log("set course RPC");
        stats.isCompleteCourse = isCompleteCourse;
    }

    public void SetEnviroment(bool isGarden)
    {
        //
        SetEnviromentRPC(isGarden);
    }
    public void SetEnviromentRPC(bool isGarden)
    {
        stats.isGardenEnviroment = isGarden;
        Debug.Log(stats.isGardenEnviroment);
        Debug.Log(isGarden);
    }

    public void setLevel(int level)
    {
        Debug.Log("set level ");
        stats.instructionNumber = level;
       setLevelRPC(level);
    }
    public void setLevelRPC(int level)
    {
        Debug.Log("set level RPC");
        stats.level = level;
        Debug.Log("LeveL : " + stats.level);
    }
    public void SetWateringCycle(int wateringCycle)
    {
        SetWateringCycleRPC(wateringCycle);
    }
    public void SetWateringCycleRPC(int wateringCycle)
    {
        stats.numberOfFlowers = wateringCycle;
        stats.totalNumberOfTasks = wateringCycle;
        Debug.Log("number of flowers " + wateringCycle);
    }

    public void SetVisualOnly(bool isVisualOnly)
    {
        stats.isVisualOnly = isVisualOnly;
    }

    public void ChooseCharacter(int characterNo)
    {
        ChooseCharacterRPC(characterNo);
    }
    public void ChooseCharacterRPC(int characterNo)
    {
        stats.character = characterNo;
    }

    public void LoadSceneRPC()
    {



        if (stats.isGardenEnviroment)
        {
            SceneManager.LoadScene("Garden");
        }
        else
        {
            SceneManager.LoadScene("Balacony");
        }

    }

    public void LoadMainMenu()
    {
        Invoke("LoadMainMenuRPC", 4f);
    }

    public void LoadMainMenuRPC()
    {
        CSVWriter.Instance.WriteCSV();
        SceneManager.LoadScene("Main Menu");
    }


    public void ExitModule()
    {
        Debug.Log("Exit Module");
        Invoke("ExitModuleRPC", 0f);
    }

    public void ExitModuleRPC()
    {
        Invoke("bye", 0f);

        Debug.Log("bye");


    }

    public void bye()
    {
        Debug.Log("Exit Module RPC");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
