using System.Numerics;

/// <summary>
/// 座標変換を担当
/// </summary>
public interface ICoordinateManager
{
    /// <summary>
    /// 画面全体内座標における正解座標取得する
    /// </summary>
    /// <param name="isUpSideImage">
    /// 上の画像における正解座標を取得するかどうか
    /// </param>
    /// <returns>
    /// 画面全体内座標における正解座標
    /// </returns>
    Vector2[] getGlobalCorrectCoordinate(int stageNumber, bool isUpSideImage);

    /// <summary>
    /// 画像内における座標を画面全体内座標に変換する
    /// </summary>
    /// <param name="coordinateInImage"></param>
    /// <param name="isUpSideImage"></param>
    /// <returns></returns>
    Vector2 exchangeToGlobalCoordinate(AnswerType coordinateInImage, bool isUpSideImage);
}