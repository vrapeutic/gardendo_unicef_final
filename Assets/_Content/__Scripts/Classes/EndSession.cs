using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSession : MonoBehaviour
{
    public static bool isExitClicked;
    public static bool isMenuClicked;
    private bool canEnterEndCanvasIEnum = true;
    bool canEnterCanvas = true;
    [SerializeField] GameObject endCanvas;
    [SerializeField] GameObject onPlayCanvas;
    [SerializeField] GameObject savePanel;
    public static EndSession instance = new EndSession();

    Statistics stats;
    private void Awake()
    {
        //Debug.Log("LeveL End : " + stats.level);
        if (instance == null) instance = this;
        else Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = Statistics.instane;
        canEnterEndCanvasIEnum = true;
    }


    public void GameOver()
    {
        EndGameCanvas();
        Debug.Log("Game Over Buton /// ");
    }

    public void GameOverRPC()
    {
        Debug.Log("Game Over Start !! ");
    }

    IEnumerator EndCanvasIEnum()
    {
        if (!canEnterEndCanvasIEnum) yield break;
        canEnterEndCanvasIEnum = false;
        if (HandleFlowersTransition.tasksAreDone) yield return new WaitForSeconds(3f);
        else yield return new WaitForSeconds(4f);
    }

    void EndGameCanvas()
    {
        if (!canEnterEndCanvasIEnum) return;
        canEnterCanvas = true;
        endCanvas.SetActive(true);
        savePanel.SetActive(false);
        onPlayCanvas.SetActive(false);
    }

    public void SaveConfirmed()
    {
        GameOver();
    }

    public void SaveDenied()
    {
         endCanvas.SetActive(true);
         savePanel.SetActive(false);
         onPlayCanvas.SetActive(false);
    }

    public void QuitSession()
    {
        savePanel.SetActive(true);
    }

}
