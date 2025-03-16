using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

/// <summary>
/// JSONファイルから各値を取り出す
/// </summary>
class JsonFileManager: IJsonFileManager
{
    private IErrorHandler errorHandler;

    public JsonFileManager(IErrorHandler errorHandler)
    {
        this.errorHandler = errorHandler;
    }

    public StageMasterData[] getMasterStageDataList()
    {
        // TODO: 実装
        return new StageMasterData[0];
    }

    public StageData? getStageData(int stageNumber)
    {
        // TODO: 実装
        return null;
    }
    
    // public AnswerType[] getAnswers(int stageNumber)
    // {
    //     try
    //     {
    //         string jsonStr = loadStringFile(Constants.answerJsonFilePath);
    //         StageAnswerType[] decoded = JsonConvert.DeserializeObject<StageAnswerType[]>(jsonStr);
    //         return decoded.First(stage => stage.stageNumber == stageNumber).answer;
    //     }
    //     catch(Exception exception)
    //     {
    //         errorHandler.loadLocalFileError(exception);
    //     }
    //     return new AnswerType[0];
    // }

    // // TODO: 実装
    // public string getStageTitle(int stageNumber)
    // {
    //     return "";
    // }

    // // TODO: 実装
    // public Dictionary<ImageType, string> getStageImagePath(int stageNumber)
    // {
    //     return new Dictionary<ImageType, string>();
    // }

    private string loadStringFile(string filePath)
    {
        string fileVal = "";
        fileVal = File.ReadAllText(filePath);

        if (fileVal == null) {
            throw new InvalidTextFileError("empty file.");
        }

        return fileVal;
    }

    // JSONからのデコードに利用
    private class StageAnswerType
    {
        public int stageNumber { get; set;}
        public AnswerType[] answer { get; set;}
    }
}