using UnityEngine;
using System.Numerics;

/// <summary>
/// ゲームオブジェクトを管理
/// </summary>
public interface IGameObjectManager
{
    /// <summary>
    /// 間違い探し画像オブジェクトを返す
    /// </summary>
    /// <param name="isUpSideImage">
    /// 上の画像かどうか
    /// </param>
    /// <returns>
    /// 間違い探し画像オブジェクト
    /// </returns>
    GameObject getMainImageObj(bool isUpSideImage);

    /// <summary>
    /// 間違い探し画像の座標を返す
    /// </summary>
    /// <param name="isUpSideImage">
    /// 上の画像かどうか
    /// </param>
    /// <returns>
    /// 間違い探し画像の座標
    /// </returns>
    System.Numerics.Vector2 getMainImagePosition(bool isUpSideImage);

    /// <summary>
    /// 間違い探し画像オブジェクトかどうかを返す
    /// </summary>
    /// <param name="obj">
    /// 判定するゲームオブジェクト
    /// </param>
    /// <returns>
    /// 間違い探し画像かどうか
    /// </returns>
    bool isImageObject(GameObject obj);
}