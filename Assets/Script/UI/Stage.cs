using UnityEngine;

[System.Serializable]
public class Stage : IStage
{
    public string stageName;
    public string description;
    public Sprite backgroundImage;
    public int stageNumber;

    public string StageName => stageName;
    public string Description => description;
    public Sprite BackgroundImage => backgroundImage;
    public int StageNumber => stageNumber;
}
