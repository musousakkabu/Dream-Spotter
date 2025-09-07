using System;
using System.Numerics;
using UnityEngine;
using System.Linq;

class TouchImageEventManager: ITouchImageEventManager
{
    private IGameEventsManager gameEventsManager;
    private IUserDataManager userDataManager;
    private ICoordinateManager coordinateManager;
    private IGameObjectManager gameObjectManager;
    
    private int stageNumber;
    private System.Numerics.Vector2[] upSideImageAnswers;
    private System.Numerics.Vector2[] downSideImageAnswers;

    public TouchImageEventManager(
        IGameEventsManager gameEventsManager, 
        IUserDataManager userDataManager,
        ICoordinateManager coordinateManager,
        IGameObjectManager gameObjectManager,
        int stageNumber
    )
    {
        this.gameEventsManager = gameEventsManager;
        this.userDataManager = userDataManager;
        this.coordinateManager = coordinateManager;
        this.gameObjectManager = gameObjectManager;

        this.stageNumber = stageNumber;
        this.upSideImageAnswers = coordinateManager.getGlobalCorrectCoordinate(stageNumber, true);
        this.downSideImageAnswers = coordinateManager.getGlobalCorrectCoordinate(stageNumber, false);
    }

    public void touchEvent()
    {
        // カメラ領域内のタッチ座標
        UnityEngine.Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // タッチされたオブジェクトが間違い探し画像かどうか確認する
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, UnityEngine.Vector2.zero);
        if (hit.collider == null || !gameObjectManager.isImageObject(hit.collider.gameObject))
        {
            // 画像以外をタッチした場合、何もしない
            return;
        }

        ResultReturnType upSideTouchResult = getTouchResult(new System.Numerics.Vector2(touchPosition.x, touchPosition.y), true);
        ResultReturnType downSideTouchResult = getTouchResult(new System.Numerics.Vector2(touchPosition.x, touchPosition.y), false);

        if (upSideTouchResult.touchResult == TouchResult.correct)
        {
            gameEventsManager.correctAnswerEvent(upSideTouchResult.correctedCoordinate, stageNumber);
        }
        if (downSideTouchResult.touchResult == TouchResult.correct)
        {
            gameEventsManager.correctAnswerEvent(downSideTouchResult.correctedCoordinate, stageNumber);
        }

        if (upSideTouchResult.touchResult == TouchResult.inCorrect && downSideTouchResult.touchResult == TouchResult.inCorrect)
        {
            gameEventsManager.inCorrectAnswerEvent();
        }
        // 既に正解済み座標の場合、何もしない
    }

    // 正誤判定をする
    private ResultReturnType getTouchResult(System.Numerics.Vector2 touchedCoordinates, bool isUpSideImageClicked)
    {
        // すでに正解済みの座標かどうか判断
        System.Numerics.Vector2[] correctedCoordinateListUpSide = userDataManager.getCorrectedAnswer(stageNumber, true);
        System.Numerics.Vector2[] correctedCoordinateListDownSide = userDataManager.getCorrectedAnswer(stageNumber, false);
        foreach (System.Numerics.Vector2 correctedCoordinate in correctedCoordinateListUpSide.Concat(correctedCoordinateListDownSide).ToArray())
        {
            bool isInsideHorizontal = correctedCoordinate.X >= touchedCoordinates.X - Constants.Numbers.CORRECT_TOUCH_RANGE && correctedCoordinate.X <= touchedCoordinates.X + Constants.Numbers.CORRECT_TOUCH_RANGE;
            bool isInsideVertical = correctedCoordinate.Y >= touchedCoordinates.Y - Constants.Numbers.CORRECT_TOUCH_RANGE && correctedCoordinate.Y <= touchedCoordinates.Y + Constants.Numbers.CORRECT_TOUCH_RANGE;
            if (isInsideHorizontal && isInsideVertical)
            {
                return new ResultReturnType(TouchResult.correctedYet, new System.Numerics.Vector2(0, 0));
            }
        }

        // 正誤判定
        System.Numerics.Vector2[] answers = isUpSideImageClicked ? upSideImageAnswers : downSideImageAnswers;
        foreach (System.Numerics.Vector2 ans in answers)
        {
            bool isInsideHorizontal = ans.X >= touchedCoordinates.X - Constants.Numbers.CORRECT_TOUCH_RANGE && ans.X <= touchedCoordinates.X + Constants.Numbers.CORRECT_TOUCH_RANGE;
            bool isInsideVertical = ans.Y >= touchedCoordinates.Y - Constants.Numbers.CORRECT_TOUCH_RANGE && ans.Y <= touchedCoordinates.Y + Constants.Numbers.CORRECT_TOUCH_RANGE;
            if (isInsideHorizontal && isInsideVertical) 
            {
                return new ResultReturnType(TouchResult.correct, ans);
            }
        }
        return new ResultReturnType(TouchResult.inCorrect, new System.Numerics.Vector2(0, 0));
    }

    private enum TouchResult
    {
        correct,
        inCorrect,
        correctedYet
    }

    // 関数getTouchResultの戻り値に利用
    private class ResultReturnType
    {
        public TouchResult touchResult;
        public System.Numerics.Vector2 correctedCoordinate;

        public ResultReturnType(TouchResult touchResult, System.Numerics.Vector2 correctedCoordinate)
        {
            this.touchResult = touchResult;
            this.correctedCoordinate = correctedCoordinate;
        }
    }
}