using UnityEngine;

public class UIManage : MonoBehaviour, IUIManager
{
    public GameObject titleCanvas;
    public GameObject tutorialCanvas;
    public GameObject stageSelectCanvas;
    public GameObject gameCanvas;
    public GameObject resultCanvas;

    // 全てのUIを非表示にする
    public void HideAllUI()
    {
        titleCanvas.SetActive(false);
        tutorialCanvas.SetActive(false);
        stageSelectCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        resultCanvas.SetActive(false);
    }

    // 指定したUIのみ表示
    public void ShowUI(string uiName)
    {
        HideAllUI();

        switch (uiName)
        {
            case "Title":
                titleCanvas.SetActive(true);
                break;
            case "Tutorial":
                tutorialCanvas.SetActive(true);
                break;
            case "StageSelect":
                stageSelectCanvas.SetActive(true);
                break;
            case "Game":
                gameCanvas.SetActive(true);
                break;
            case "Result":
                resultCanvas.SetActive(true);
                break;
        }
    }
}
