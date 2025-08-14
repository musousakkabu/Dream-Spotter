using UnityEngine;

public class GameStateManager : MonoBehaviour, IGameStateManager
{
    public enum GameState
    {
        Title,
        Tutorial,
        StageSelect,
        Playing,
        Result,
        GameOver
    }

    private GameState currentState;
    private Stage selectedStage;  // 選ばれたステージ情報
<<<<<<< Updated upstream
    public UIManager uiManage;    // UIManagerへの参照
=======
    public UIManager uiManage;    // UIManageへの参照
>>>>>>> Stashed changes
    //public IUserDataManager userDataManager;  // IUserDataManagerの参照
    private int missCount; // ミス回数
    private float clearTime; // クリア時間（秒）

    private const string TutorialDoneKey = "TutorialDone"; // PlayerPrefsのキー

    private float timeBeforeAutoTransition = 5f;  // タイトル画面から自動で遷移する時間（秒）
    private float timeElapsed = 0f;  // 経過時間

    private void Start()
    {
        // 初期状態はタイトル画面を表示
        ChangeState(GameState.Title);
        //uiManage.SetGameStateManager(this);
    }

    private void Update()
    {
        // タイトル画面のとき、時間が経過したら自動で次の画面へ遷移
        if (currentState == GameState.Title)
        {
            timeElapsed += Time.deltaTime;  // 経過時間をカウント

            if (timeElapsed >= timeBeforeAutoTransition)
            {
                // チュートリアルが未完了の場合、チュートリアル画面へ遷移
                if (IsTutorialDone())
                {
                    ChangeState(GameState.Tutorial);
                }
                else
                {
                    // チュートリアルが完了している場合、ステージ選択画面へ遷移
                    ChangeState(GameState.StageSelect);
                }
            }
        }

        // チュートリアル中にクリックでクリア → ステージ選択へ
        if (currentState == GameState.Tutorial && Input.GetMouseButtonDown(0))
        {
            MarkTutorialAsComplete();
            ChangeState(GameState.StageSelect);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"ゲーム状態が変更されました: {currentState}");

        switch (currentState)
        {
            case GameState.Title:
                uiManage.ShowUI("Title");
                break;

            case GameState.Tutorial:
                uiManage.ShowUI("Tutorial");
                break;

            case GameState.Result:
                uiManage.ShowUI("Result");
                uiManage.ShowClearResult(missCount, clearTime); // ミス回数とクリア時間を表示
                //Invoke("AutoTransitionToStageSelectFromResult", 3f); // TODO: 関数AutoTransitionToStageSelectFromResultの実装
                break;

            case GameState.StageSelect:
                uiManage.ShowUI("StageSelect");
                break;

            case GameState.Playing:
                uiManage.ShowUI("Game");
                StartGame();
                break;

            /*case GameState.GameOver:
                uiManage.ShowUI("GameOver");
                //Invoke(nameof(AutoTransitionToTitleFromGameOver), 3f); // 3秒後にタイトルへ
                break;
            */
        }
    }

    // チュートリアルが完了したかをPlayerPrefsで確認
    public bool IsTutorialDone()
    {
<<<<<<< Updated upstream
        return PlayerPrefs.GetInt(TutorialDoneKey, 0) == 0; // チュートリアルが完了した場合は1、未完了の場合は0
=======
        return PlayerPrefs.GetInt(TutorialDoneKey, 0) ==1; // チュートリアルが完了した場合は1、未完了の場合は0
>>>>>>> Stashed changes
    }

    // チュートリアル完了の状態を保存
    public void MarkTutorialAsComplete()
    {
        PlayerPrefs.SetInt(TutorialDoneKey, 1); // チュートリアル完了として保存
        PlayerPrefs.Save();
    }

    public void SetSelectedStage(Stage stage)
    {
        selectedStage = stage;
    }

    public void StartGame()
    {
        if (selectedStage != null)
        {
            Debug.Log($"ゲーム開始: {selectedStage.stageName}");
        }
        else
        {
            Debug.LogWarning("ステージが選択されていません。");
        }
    }

    private void AutoTransitionToTitleFromGameOver()
    {
        if (currentState == GameState.GameOver)
        {
            ChangeState(GameState.Title); // ゲームオーバー後はタイトル画面へ
        }
    }

    // konnbannゲームクリアかどうかを判定するメソッド
    private bool IsGameClear()
    {
        // 例: selectedStage.stageNumber が特定のステージ番号（例えば 10）ならクリアとする
        if (selectedStage != null && selectedStage.stageNumber == 10)
        {
            return true;
        }
        return false;
    }

    private bool IsGameOver()
    {
        if (selectedStage == null)
        {
            return true;
        }
        return false;
    }

    private void ResetStage()
    {
        missCount = 0;
        clearTime = 0f;
        // 必要ならステージデータもリセット
    }

    public void OnRetryButtonPressed()
    {
        if (selectedStage != null)
        {
            Debug.Log("ステージをリトライします");
            // ミスカウントやタイマーなどもリセット
            ResetStage();
            ChangeState(GameState.Playing);
        }
        else
        {
            Debug.LogWarning("リトライできません。ステージが未選択です。");
        }
    }

    // 途中のゲームに戻る
    public void ContinueGameButtonPressed()
    {
        if (selectedStage != null)
        {
            Debug.Log("途中のゲームに戻ります");
            uiManage.ShowUI("Game");
            // 必要ならゲームの進行状態を復元
        }
        else
        {
            Debug.LogWarning("途中のゲームに戻れません。ステージが未選択です。");
        }
    }


    public void OnSelectButtonPressed()
    {
        ChangeState(GameState.StageSelect);
    }

    // オプションボタン押下時
    public void OnOptionButtonPressed()
    {
        uiManage.ShowUI("Option");
    }

    // ヒントボタン押下時
    public void OnHintButtonPressed()
    {
        uiManage.ShowUI("Hint");
    }
}
