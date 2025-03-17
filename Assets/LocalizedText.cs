using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string englishText;
    [SerializeField]
    private string arabicText;
    [SerializeField]
    private string vietnameseText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        var tmpText = this.GetComponent<TextMeshProUGUI>();
        switch (Statistics.languageIndex)
        {
            case 1:
                tmpText.SetText(vietnameseText);
                break;
            case 2:
                tmpText.SetText(englishText);
                break;
            case 3:
                tmpText.SetText(englishText);
                break;
            default:
                tmpText.SetText(englishText);
                break;
        }
    }
}
