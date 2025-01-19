using System.Numerics;
using System.Collections.Generic;

/// <summary>
/// JSONファイルから各値を取り出す
/// </summary>
public interface IJsonFileManager
{
    /// <summary>
    /// 正解座標を返す(画像内を百等分したときの座標。原点画像中心。)
    /// </summary>
    /// <param>
    /// stageNumber: ステージ番号
    /// </param>
    /// <returns>
    /// 正解座標の配列
    /// </returns> 
    AnswerType[] getAnswers(int stageNumber);

    /// <summary>
    /// ステージタイトルを返す
    /// </summary>
    /// <param>
    /// stageNumber: ステージ番号
    /// </param>
    /// <returns>
    /// ステージタイトル
    /// </returns> 
    string getStageTitle(int stageNumber);

    /// <summary>
    /// 間違い探し画像のパスを取得する
    /// </summary>
    /// <param>
    /// ステージ番号
    /// </param> 
    /// <returns>
    /// 間違い探し画像のパス
    /// </returns>
    Dictionary<ImageType, string> getStageImagePath(int stageNumber);
}

/// <summary>
/// 間違い探し画像の種類(上に表示するもの、下に表示するもの)
/// </summary>
public enum ImageType
{
    up,
    down,
}