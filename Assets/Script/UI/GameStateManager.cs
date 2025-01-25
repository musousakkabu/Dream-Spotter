using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Tutorial,
        StageSelect,
        Playing,
        Result
    }

    private GameState currentState;
    private Stage selectedStage;  // 選ばれたステージ情報

    private void Start()
    {
        ChangeState(GameState.Title);
    }

    private void Update()
    {
        // 現在の状態に応じた自動遷移
        switch (currentState)
        {
            case GameState.Title:
                // タイトル画面表示後、3秒後に自動でチュートリアルに移行
                Invoke("AutoTransitionToTutorial", 3f);
                break;
            case GameState.Tutorial:
                // チュートリアル終了後、3秒後にステージ選択画面に移行
                Invoke("AutoTransitionToStageSelect", 3f);
                break;
        }
    }

    private void AutoTransitionToTutorial()
    {
        if (currentState == GameState.Title)
        {
            ChangeState(GameState.Tutorial);
        }
    }

    private void AutoTransitionToStageSelect()
    {
        if (currentState == GameState.Tutorial)
        {
            ChangeState(GameState.StageSelect);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;

        // 各状態に応じた処理
        switch (currentState)
        {
            case GameState.Title:
                ShowTitleUI();
                break;
            case GameState.Tutorial:
                ShowTutorialUI();
                break;
            case GameState.StageSelect:
                ShowStageSelectUI();
                break;
            case GameState.Playing:
                StartGame();
                break;
            case GameState.Result:
                ShowResultUI();
                break;
        }
    }

    public void SetSelectedStage(Stage stage)
    {
        selectedStage = stage;
    }

    private void ShowTitleUI()
    {
        Debug.Log("タイトル画面を表示");
    }

    private void ShowTutorialUI()
    {
        Debug.Log("チュートリアル画面を表示");
    }

    private void ShowStageSelectUI()
    {
        Debug.Log("ステージ選択画面を表示");
    }

    private void StartGame()
    {
        // ステージ情報に基づいた処理
        Debug.Log("ゲーム開始: " + selectedStage.stageName);
        // 背景画像の変更
        //backgroundImage.sprite = selectedStage.backgroundImage;  // ゲーム内の背景画像に設定
    }

    private void ShowResultUI()
    {
        Debug.Log("結果画面を表示");
    }
}
