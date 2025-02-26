using System.Numerics;

public class UserDataManager: IUserDataManager
{
    public void setLastSelectedStageNumber() {}

    public int getLastSelectedStageNumber()
    {
        // TODO: これは動作確認用
        return 0;
    }

    public void saveCorrectedAnswer(Vector2 correctedCoordinate, int stageNumber) {}

    public Vector2[] getCorrectedAnswer(int stageNumber, bool isUpSide) {
        return new Vector2[0];
        // TODO: 正解した座標は上下どちらも同じなので、画像によって変換して返す
    }

    public void saveResolvedStageNumber(int stageNumber) {}

    public void saveIsDoneTutorial() {}

    public void saveSoundSetting(int soundVolumeLevel) {}
}
