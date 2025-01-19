using System;
using UnityEngine;

class ErrorHandler: IErrorHandler
{
    public ErrorHandler() {}

    public void loadLocalFileError(Exception error)
    {
        Debug.LogError(error.Message);
        //TODO: ここでファイル読み込みエラー時の処理を行う
    }

    public void invalidObjectNameError(Exception error)
    {
        Debug.LogError(error.Message);
        //TODO: ここでエラー時の処理を行う
    }

    public void colliderNotFoundError(Exception error)
    {
        Debug.LogError(error.Message);
        //TODO: ここでエラー時の処理を行う
    }
}