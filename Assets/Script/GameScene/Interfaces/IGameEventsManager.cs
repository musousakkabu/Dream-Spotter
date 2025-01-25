using System.Numerics;

/// <summary>
/// ゲーム進行に関わるイベント管理を担当
/// </summary>
public interface IGameEventsManager
{
    /// <summary>
    /// ゲームスタート時のイベント
    /// シーン内各オブジェクトにスクリプトアタッチや、bgm再生、ステージタイトル表示、画像表示などを行う 
    /// </summary>
    void gameStartEvent();

    /// <summary>
    /// 正解時イベント
    /// </summary>
    void correctAnswerEvent(Vector2 correctedCoordinate, int stageNumber);

    /// <summary>
    /// 不正解時イベント
    /// </summary>
    void inCorrectAnswerEvent();

    /// <summary>
    /// ステージクリアイベント
    /// </summary>
    void stageClearEvent(int stageNumber);

    /// <summary>
    /// ゲームオーバーイベント
    /// </summary>
    void gameOverEvent();

    /// <summary>
    /// ヒント表示を行う(広告表示なども行う)
    /// ヒント残り回数を確認し、表示の可否も判断する 
    /// </summary>
    /// <param>
    /// stageNumber: ステージ番号
    /// </param> 
    void openHintEvent(int stageNumber);

    /// <summary>
    /// ヒントを閉じるときに利用する
    /// </summary>
    void closeHintEvent();

    // TODO: 設定画面を開くのは、設定管理クラスを別途用意し、そこで行う
}