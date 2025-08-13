using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro を使う

public class UIManager : MonoBehaviour, IUIManager
{
    public GameObject titleCanvas;
    public GameObject tutorialCanvas;
    public GameObject stageSelectCanvas;
    public GameObject gameCanvas;
    public GameObject resultCanvas;
    public GameObject gameOverCanvas;
    public Button retryButton;
    public Button backToStageSelectButton;
    public Button nextButton; 

    private GameStateManager gameStateManager;

    public TextMeshProUGUI resultText; // 結果表示用のテキスト

    // 全てのUIを非表示にする
    public void HideAllUI()
    {
        titleCanvas.SetActive(false);
        tutorialCanvas.SetActive(false);
        stageSelectCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        resultCanvas.SetActive(false);

        nextButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        backToStageSelectButton.gameObject.SetActive(false);
    }

    public void ShowClearResult(int missCount, float clearTime)
    {
        resultText.text = $"ミス回数: {missCount}\nクリア時間: {clearTime:F2}秒";
        nextButton.gameObject.SetActive(true); // ← クリア時に表示
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
