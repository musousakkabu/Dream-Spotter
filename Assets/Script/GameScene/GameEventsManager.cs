using System.Numerics;
using UnityEngine;
using System.Linq;

class GameEventsManager: IGameEventsManager
{

    private IUserDataManager userDataManager;
    private ICoordinateManager coordinateManager;
    
    private int inCorrectCount;

    public GameEventsManager(IUserDataManager userDataManager, ICoordinateManager coordinateManager)
    {
        this.userDataManager = userDataManager;
        this.coordinateManager = coordinateManager;
        this.inCorrectCount = 0;
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
        // TODO: ここで不正解時エフェクトなどを発火する

        inCorrectCount++;

        if (inCorrectCount > Constants.baseLifeCount) 
        {
            gameOverEvent();
        }
    }

    public void stageClearEvent(int stageNumber) 
    {
        Debug.Log("stage clear");
        // TODO: ステージクリア時の処理
    }

    public void gameOverEvent() 
    {
        Debug.Log("game over");
        // TODO: ゲームオーバー時の処理
    }

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