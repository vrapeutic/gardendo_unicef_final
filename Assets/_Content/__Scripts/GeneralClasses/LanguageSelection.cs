using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelection : MonoBehaviour
{
    [SerializeField] MeunuSequence menuSequence;

    public void OnLanguageSelect(int languageNO)
    {
        OnLanguageSelectRPC(languageNO);
    }

    public void OnLanguageSelectRPC(int languageNO)
    {
        Statistics.languageIndex = languageNO;
    }
}

