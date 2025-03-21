using System.Numerics;
using System.Collections.Generic;

/// <summary>
/// JSONファイルから各値を取り出す
/// </summary>
public interface IJsonFileManager
{
    /// <summary>
    /// ステージの情報をすべて取得する
    /// </summary>
    /// <returns></returns>
    StageMasterData[] getMasterStageDataList();

    /// <summary>
    /// ステージの詳細情報を取得する
    /// </summary>
    /// <param name="stageNumber">
    /// ステージ番号
    /// </param>
    /// <returns>
    /// ステージの詳細情報
    /// </returns>
    StageData? getStageData(int stageNumber);
}
