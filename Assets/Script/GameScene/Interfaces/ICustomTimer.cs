/// <summary>
/// タイマー操作担当
/// </summary>
public interface ICustomTimer
{
    /// <summary>
    /// 制限時間タイマーをスタートする
    /// </summary>
    void StartTimer();

    /// <summary>
    /// 制限時間タイマーをストップする
    /// </summary>
    void StopTimer();

    /// <summary>
    /// タイマーを最初の時間から再開する
    /// </summary>
    void ResetTimer();

    /// <summary>
    /// タイマーの残り時間を減らす
    /// </summary>
    ///  <param>
    /// increaseSec: 減らす秒数
    /// </param>
    void DecreaseSec(float decreaseSec);

    /// <summary>
    /// タイマーの残り時間を一フレーム分減らす
    /// </summary>
    void DecreaseFrame();

    /// <summary>
    /// タイマーの残り時間を増やす(DecreaseTimeと同様で何かのイベントでタイマーの時間を操作するときに利用)
    /// </summary>
    /// <param>
    /// increaseSec: 増やす秒数
    /// </param>
    void increaseTimer(float increaseSec);

    /// <summary>
    /// 現在の残り時間を取得する(Viewに表示するときや、リザルト画面に使用)
    /// </summary>
    /// <returns>
    /// タイマーの残り時間
    /// </returns>
    float getTime();

    /// <summary>
    /// タイマーが起動しているかどうかを取得する
    /// </summary>
    /// <returns>
    /// タイマーが起動しているかどうか
    /// </returns>
    bool getIsTimerActive();
}