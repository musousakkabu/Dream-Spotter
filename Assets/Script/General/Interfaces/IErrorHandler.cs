using System;

/// <summary>
/// 各エラーに対する処理を担当
/// </summary>
public interface IErrorHandler
{
    /// <summary>
    /// ローカルファイルの読み取りに失敗したときの処理
    /// </summary>
    void loadLocalFileError(Exception error);
}