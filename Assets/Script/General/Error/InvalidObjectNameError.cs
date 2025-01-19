using System;

/// <summary>
/// 不正なオブジェクト名エラー
/// </summary>
public class InvalidObjectNameError : Exception
{
    public InvalidObjectNameError() : base("This object name is invalid.") { }

    public InvalidObjectNameError(string message) : base(message) { }

    public InvalidObjectNameError(string message, Exception innerException) : base(message, innerException) { }

    public int ErrorCode { get; set; }
}