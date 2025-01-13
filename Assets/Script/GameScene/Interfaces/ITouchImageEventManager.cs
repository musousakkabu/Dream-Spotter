using System.Numerics;

/// <summary>
/// 間違い探し画像をタッチしたときのイベントを管理
/// </summary>
interface ITouchImageEventManager
{
    /// <summary>
    /// タッチしたときのイベント。(正誤判定)(エフェクト再生、音再生も行う)
    /// </summary>
    /// <param>
    /// touchedCoordinates: タッチ座標
    /// </param>
    void touchEvent(Vector2 touchedCoordinates);
}