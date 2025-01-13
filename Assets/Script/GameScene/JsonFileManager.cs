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
    public AnswerType[] getAnswers(int stageNumber)
    {
        string jsonStr = loadStringFile(Constants.answerJsonFilePath);
        StageAnswerType[] decoded = JsonConvert.DeserializeObject<StageAnswerType[]>(jsonStr);
        return decoded.First(stage => stage.stageNumber == stageNumber).answer;
    }

    // TODO: 実装
    public string getStageTitle(int stageNumber)
    {
        return "";
    }

    // TODO: 実装
    public Dictionary<ImageType, string> getStageImagePath(int stageNumber)
    {
        return new Dictionary<ImageType, string>();
    }

    private string loadStringFile(string filePath)
    {
        string fileVal = "";
        fileVal = File.ReadAllText(filePath);

        if (fileVal == null) {
            throw new InvalidTextFileError("empty file.");
        }

        return fileVal;
    }

    private class StageAnswerType
    {
        public int stageNumber { get; set;}
        public AnswerType[] answer { get; set;}
    }
}