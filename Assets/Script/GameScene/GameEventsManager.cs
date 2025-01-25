using System.Numerics;
using UnityEngine;
using System.Linq;

class GameEventsManager: IGameEventsManager
{

    private IUserDataManager userDataManager;
    private ICoordinateManager coordinateManager;

    public GameEventsManager(IUserDataManager userDataManager, ICoordinateManager coordinateManager)
    {
        this.userDataManager = userDataManager;
        this.coordinateManager = coordinateManager;
    }

    public void gameStartEvent() {}

    public void correctAnswerEvent(System.Numerics.Vector2 correctedCoordinate, int stageNumber) {
        Debug.Log("correct");
        // TODO: ここで正解時エフェクトなどを発火する

        // 正解した座標を保存する
        userDataManager.saveCorrectedAnswer(correctedCoordinate, stageNumber);
        // すべて正解したか判定する
        if (getIsAllCorrected(stageNumber))
        {
            stageClearEvent(stageNumber);
        }
    }

    public void inCorrectAnswerEvent() {
        Debug.Log("not correct");
    }

    public void stageClearEvent(int stageNumber) {}

    public void gameOverEvent() {}

    public void openHintEvent(int stageNumber) {}

    public void closeHintEvent() {}

    private bool getIsAllCorrected(int stageNumber)
    {
        // 上の画像として判定する(上でも下でもどちらでも良いが、グローバル座標なのでどちらか統一しないといけない)
        System.Numerics.Vector2[] correctedCoordinate = userDataManager.getCorrectedAnswer(stageNumber, true);
        System.Numerics.Vector2[] allAnswerCoordinate = coordinateManager.getGlobalCorrectCoordinate(stageNumber, true);
        return allAnswerCoordinate.All(answer => correctedCoordinate.Contains(answer));
    }
}