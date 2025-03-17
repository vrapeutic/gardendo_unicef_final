using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterSelection : MonoBehaviour
{
    [SerializeField]
    GameObject Hussien;
    [SerializeField]
    GameObject Reem;
    [SerializeField]
    GameObject Rich;
    [SerializeField]
    GameObject Liza;
    [SerializeField]
    GameObject HussienSU;
    [SerializeField]
    GameObject ReemSU;
    [SerializeField]
    GameObject vietnamMale;
    [SerializeField]
    GameObject vietnamFemale;

    Statistics stats;
    private void Start()
    {
        stats = Statistics.instane;
        if (Statistics.languageIndex == 1)
        {
            Debug.Log("vietnam language selsected");
            if (stats.character == 1)
            {
                //  if (gameObject.tag == "HussienAR") ;
                vietnamMale.SetActive(true);
                Debug.Log("vietnamMale selsected ");
            }
            else if (stats.character == 2)
            {
                vietnamFemale.SetActive(true);
                Debug.Log("vietnam female selsected ");
            }
        }
        else if (Statistics.languageIndex == 2)
        {
            Debug.Log("english language selsected");
            if (stats.character == 1)
            {
                //  if (gameObject.tag == "HussienENG") ;
                Rich.SetActive(true);
                Debug.Log("rich female selsected ");
            }
            else if (stats.character == 2)
            {
                //  if (gameObject.tag == "ReemENG") ;
                Liza.SetActive(true);
                Debug.Log("liza female selsected ");
            }
        }
        //else
        //{
        //    Debug.Log("language selsected error");
        //}
        else if (Statistics.languageIndex == 3)
        {
            if (stats.character == 1)
            {
                 //if (gameObject.tag == "HussienSU") ;
                Hussien.SetActive(true);
            }
            else if (stats.character == 2)
            {
                Reem.SetActive(true);
            }
        }

    }
    public void GetReadyToWaterFLowerInWateringCourse()
    {
        this.GetComponent<AnimationEventsHandler>().HandleEvent(4);
    }
}
