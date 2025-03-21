/// <summary>
/// ステージの主要情報をまとめた型(主にステージ選択画面で利用)
/// </summary>
public class StageMasterData
{
    /// <summary>
    /// ステージ識別番号
    /// </summary>
    public int stageNumber { get; }

    /// <summary>
    /// タイトル文字列
    /// </summary>
    public string title { get;}

    /// <summary>
    /// ステージに対する説明文
    /// </summary>
    public string context { get; }

    /// <summary>
    /// サムネイルファイルパス(Assets配下)(ステージ選択画面にて利用)
    /// </summary>
    public string thumbnailPath { get; }

    /// <summary>
    /// 難易度(0スタート)
    /// </summary>
    public int difficulty { get; }
}