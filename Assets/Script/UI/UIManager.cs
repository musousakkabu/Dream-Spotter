using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro を使う

public class UIManager : MonoBehaviour, IUIManager
{
    public Button retryButton;
    public Button ContinueButton;
    public Button homeButton;
    public Button optionButton;       // 右上のメニューボタン
    public Button hintButton;       // ヒントボタン

    private GameStateManager gameStateManager;
    public GameObject titleCanvas;
    public GameObject tutorialCanvas;
    public GameObject stageSelectCanvas;
    public GameObject gameCanvas;
    public GameObject resultCanvas;
    public GameObject optionCanvas;  // オプションメニューのPanel
    public GameObject hintCanvas;    // ヒントを表示するUI


    public TextMeshProUGUI resultText; // 結果表示用のテキスト

    public void SetGameStateManager(GameStateManager manager)
    {
        gameStateManager = manager;

        retryButton.onClick.AddListener(() => gameStateManager.OnRetryButtonPressed());
        ContinueButton.onClick.AddListener(() => gameStateManager.ContinueGameButtonPressed());
        homeButton.onClick.AddListener(() => gameStateManager.OnSelectButtonPressed());
        // オプションボタン
        optionButton.onClick.AddListener(() => gameStateManager.OnOptionButtonPressed());
        // ヒントボタン
        hintButton.onClick.AddListener(() => gameStateManager.OnHintButtonPressed());
    }

    void ShowHint()
    {
        hintCanvas.SetActive(true);
        // 必要ならテキスト変更やアニメーションを追加
    }

    // 全てのUIを非表示にする
    public void HideAllUI()
    {
        titleCanvas.SetActive(false);
        tutorialCanvas.SetActive(false);
        stageSelectCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        resultCanvas.SetActive(false);
        optionCanvas.SetActive(false);
        hintCanvas.SetActive(false);

    }

    public void ShowClearResult(int missCount, float clearTime)
    {
        resultText.text = $"ミス回数: {missCount}\nクリア時間: {clearTime:F2}秒";
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
            case "Option":
                optionCanvas.SetActive(true);
                break;
            case "Hint":
                hintCanvas.SetActive(true);
                break;
        }
    }
}
