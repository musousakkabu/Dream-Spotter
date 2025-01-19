using System;

/// <summary>
/// コライダーが見つからないエラー
/// </summary>
public class ColliderNotFoundError : Exception
{
    public ColliderNotFoundError() : base("Collider was not Found.") { }

    public ColliderNotFoundError(string message) : base(message) { }

    public ColliderNotFoundError(string message, Exception innerException) : base(message, innerException) { }

    public int ErrorCode { get; set; }
}