using UnityEngine;

public class GameStateManager : MonoBehaviour
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
    public UIManage uiManage;    // UIManageへの参照
    //public IUserDataManager userDataManager;  // IUserDataManagerの参照
    private int missCount; // ミス回数
    private float clearTime; // クリア時間（秒）

    private const string TutorialDoneKey = "TutorialDone"; // チュートリアル完了フラグ用

    private void Start()
    {
        if (IsTutorialDone())
        {
            ChangeState(GameState.Title);
        }
        else
        {
            ChangeState(GameState.Tutorial);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"ゲーム状態が変更されました: {currentState}");

        // 状態ごとの処理を実行
        switch (currentState)
        {
            case GameState.Title:
                uiManage.ShowUI("Title");
                Invoke(nameof(AutoTransitionToTutorial), 3f);
                break;

            case GameState.Tutorial:
                uiManage.ShowUI("Tutorial");
                Invoke(nameof(AutoTransitionToResult), 3f); // チュートリアル完了後に結果画面へ
                break;

            case GameState.Result:
                uiManage.ShowUI("Result");
                uiManage.ShowClearResult(missCount, clearTime); // ミス回数とクリア時間を表示
                Invoke(nameof(AutoTransitionToStageSelectFromResult), 3f);
                break;

            case GameState.StageSelect:
                uiManage.ShowUI("StageSelect");
                break;

            case GameState.Playing:
                uiManage.ShowUI("Game");
                StartGame();
                break;

            case GameState.GameOver:
                uiManage.ShowUI("GameOver");
                Invoke(nameof(AutoTransitionToTitleFromGameOver), 3f); // 3秒後にタイトルへ
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

    private void AutoTransitionToResult()
    {
        if (currentState == GameState.Tutorial)
        {
            //userDataManager.saveIsDoneTutorial(); // チュートリアル完了を保存
            // ゲームクリアまたはゲームオーバーを判定して遷移
            if (IsGameClear())
            {
                ChangeState(GameState.Result);  // ゲームクリア
            }
            else if (IsGameOver())
            {
                ChangeState(GameState.GameOver);  // ゲームオーバー
            }
        }
    }

    private void AutoTransitionToStageSelectFromResult()
    {
        if (currentState == GameState.Result)
        {
            ChangeState(GameState.StageSelect); // 結果画面からセレクト画面へ遷移
        }
    }

    public void SetSelectedStage(Stage stage)
    {
        selectedStage = stage;
    }

    private void StartGame()
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


    // チュートリアル完了状態を取得
    private bool IsTutorialDone()
    {
        return PlayerPrefs.GetInt(TutorialDoneKey, 0) == 1;  // PlayerPrefsからチュートリアル完了情報を取得
    }

    // ゲームクリアかどうかを判定するメソッド
    private bool IsGameClear()
    {
        // ここでゲームクリアの判定を行う。例えば、ステージの最後に到達した場合など
        // 例: selectedStage が最後のステージの場合
        /*if (selectedStage != null && selectedStage.stageNumber == 10)  // ステージ番号が10ならクリアとする
        {
            return true;
        }*/
        return false;
    }

    // ゲームオーバーかどうかを判定するメソッド
    private bool IsGameOver()
    {
        // ここでゲームオーバーの判定を行う。例えば、残機がなくなった場合など
        // 例: selectedStage が null か、ゲームの終了条件を満たした場合
        if (selectedStage == null) // ステージが選ばれていない場合、ゲームオーバーとする
        {
            return true;
        }
        return false;
    }
}
