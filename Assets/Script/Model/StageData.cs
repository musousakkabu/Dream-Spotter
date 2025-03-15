/// <summary>
/// ステージの詳細情報をまとめた型(主にゲーム画面で利用)
/// </summary>
public class StageMasterData
{
    /// <summary>
    /// 間違い探し画像のパス文字列(Assets配下)
    /// </summary>
    public <ImageType, string> imagePath { get; }

    /// <summary>
    /// 正解座標の配列
    /// </summary>
    public AnswerType[] answerList { get; }

    /// <summary>
    /// 難易度(0スタート)
    /// </summary>
    public int difficulty { get; }

    /// <summary>
    /// ステージクリア画面に表示する画像のパス
    /// </summary>
    public string clearImagePath { get; }

    /// <summary>
    /// ゲームオーバー画面に表示する画像のパス
    /// </summary>
    public string gameOverImagePath { get; }

    /// <summary>
    /// ステージクリア画面に表示する文字列
    /// </summary>
    public string clearText { get; }

    /// <summary>
    /// ゲームオーバー画面に表示する文字列
    /// </summary>
    public string gameOverText { get; }
}