public interface IGameStateManager
{
    // ゲームの状態を変更する
    void ChangeState(GameStateManager.GameState newState);

    // チュートリアルが完了したかどうかを確認する
    bool IsTutorialDone();

    // チュートリアル完了を記録する
    void MarkTutorialAsComplete();

    // ステージを選択する
    void SetSelectedStage(Stage stage);

    // ゲーム開始処理
    void StartGame();
}
