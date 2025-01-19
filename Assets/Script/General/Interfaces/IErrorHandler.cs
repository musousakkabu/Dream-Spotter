using System;

/// <summary>
/// 各エラーに対する処理を担当
/// </summary>
public interface IErrorHandler
{
    /// <summary>
    /// ローカルファイルの読み取りに失敗したときの処理
    /// </summary>
    /// <param name="error">
    /// エラーオブジェクト
    /// </param>
    void loadLocalFileError(Exception error);

    /// <summary>
    /// ゲームオブジェクトの呼び出しに失敗した時のエラー
    /// </summary>
    /// <param name="error">
    /// エラーオブジェクト
    /// </param>
    void invalidObjectNameError(Exception error);
}