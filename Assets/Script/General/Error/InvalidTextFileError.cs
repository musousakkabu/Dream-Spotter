using System;

/// <summary>
/// 不正なテキストファイルを読んだ時のエラー
/// </summary>
public class InvalidTextFileError : Exception
{
    public InvalidTextFileError() : base("This text file is invalid.") { }

    public InvalidTextFileError(string message) : base(message) { }

    public InvalidTextFileError(string message, Exception innerException) : base(message, innerException) { }

    public int ErrorCode { get; set; }
}