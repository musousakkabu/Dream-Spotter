/// <summary>
/// タイマー操作担当
/// </summary>
interface ITimer
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
    /// タイマーの残り時間を減らす(タイマーは起動したら自動で時間が減るが、この関数はそれとは関係なく何かのイベントで減らすときに利用する)
    /// </summary>
    ///  <param>
    /// increaseSec: 減らす秒数
    /// </param>
    void DecreaseTime(int decreaseSec);

    /// <summary>
    /// タイマーの残り時間を増やす(DecreaseTimeと同様で何かのイベントでタイマーの時間を操作するときに利用)
    /// </summary>
    /// <param>
    /// increaseSec: 増やす秒数
    /// </param>
    void increaseTimer(int increaseSec);
}