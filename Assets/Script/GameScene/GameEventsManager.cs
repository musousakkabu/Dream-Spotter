using System.Numerics;
using UnityEngine;

class GameEventsManager: IGameEventsManager
{

    private IUserDataManager userDataManager;

    public GameEventsManager(IUserDataManager userDataManager)
    {
        this.userDataManager = userDataManager;
    }

    public void gameStartEvent() {}

    public void correctAnswerEvent(System.Numerics.Vector2 correctedCoordinate, int stageNumber) {
        Debug.Log("correct");
        userDataManager.saveCorrectedAnswer(correctedCoordinate, stageNumber);
    }

    public void inCorrectAnswerEvent() {
        Debug.Log("not correct");
    }

    public void stageClearEvent() {}

    public void gameOverEvent() {}

    public void openHintEvent(int stageNumber) {}

    public void closeHintEvent() {}
}