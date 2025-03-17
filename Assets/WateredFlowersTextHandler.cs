using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WateredFlowersTextHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tmpText = this.GetComponentInChildren<TextMeshProUGUI>();
        switch (Statistics.languageIndex)
        {
            case 1:
                tmpText.SetText("Hoa Đã Tưới\n 0");
                break;
            case 2:
                tmpText.SetText("Flowers Watered\n 0");
                break;
            case 3:
                tmpText.SetText("Flowers Watered\n 0");
                break;
            default:
                tmpText.SetText("Flowers Watered\n 0");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWateredFlowersText()
    {
        var tmpText = this.GetComponentInChildren<TextMeshProUGUI>();
        switch (Statistics.languageIndex)
        {
            case 1:
                tmpText.SetText($"Hoa Đã Tưới\n {Statistics.instane.currentFlowerIndex}");
                break;
            case 2:
                tmpText.SetText($"Flowers Watered\n {Statistics.instane.currentFlowerIndex}");
                break;
            case 3:
                tmpText.SetText($"Flowers Watered\n {Statistics.instane.currentFlowerIndex}");
                break;
            default:
                tmpText.SetText($"Flowers Watered\n {Statistics.instane.currentFlowerIndex}");
                break;
        }
    }
}
