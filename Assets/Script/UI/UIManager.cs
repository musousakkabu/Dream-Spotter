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
<<<<<<< Updated upstream
    public GameObject gameOverCanvas;
    public Button retryButton;
    public Button backToStageSelectButton;
    public Button nextButton; 

    private GameStateManager gameStateManager;
=======
    public GameObject optionCanvas;  // オプションメニューのPanel
    public GameObject hintCanvas;    // ヒントを表示するUI
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream

        nextButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        backToStageSelectButton.gameObject.SetActive(false);
=======
        optionCanvas.SetActive(false);
        hintCanvas.SetActive(false);
>>>>>>> Stashed changes
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
            case "Option":
                optionCanvas.SetActive(true);
                break;
            case "Hint":
                hintCanvas.SetActive(true);
                break;
        }
    }
}
