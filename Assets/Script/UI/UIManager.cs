using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject tutorialCanvas;
    public GameObject stageSelectCanvas;
    public GameObject gameCanvas;
    public GameObject resultCanvas;

    public void ShowUI(string uiName)
    {
        titleCanvas.SetActive(uiName == "Title");
        tutorialCanvas.SetActive(uiName == "Tutorial");
        stageSelectCanvas.SetActive(uiName == "StageSelect");
        gameCanvas.SetActive(uiName == "Game");
        resultCanvas.SetActive(uiName == "Result");
    }
}
