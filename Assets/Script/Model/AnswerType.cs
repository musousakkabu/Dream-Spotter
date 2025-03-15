/// <summary>
/// 正解座標を表す型
/// </summary>
public class AnswerType
{
    /// <summary>
    /// 正解座標を識別する番号
    /// </summary>
    public int answerNumber { get; }

    /// <summary>
    /// 画像を100等分したときに横軸中心からいくつの座標かを表す
    /// </summary>
    public int x { get; }

     /// <summary>
    /// 画像を100等分したときに縦軸中心からいくつの座標かを表す
    /// </summary>
    public int y { get; }
}