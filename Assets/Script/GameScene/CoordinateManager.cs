using UnityEngine;
using System.Numerics;
using System.Linq;

class CoordinateManager: ICoordinateManager
{
    private IJsonFileManager jsonFileManager;
    private IErrorHandler errorHandler;
    private IGameObjectManager gameObjectManager;

    public CoordinateManager(IJsonFileManager jsonFileManager, IErrorHandler errorHandler, IGameObjectManager gameObjectManager)
    {
        this.jsonFileManager = jsonFileManager;
        this.errorHandler = errorHandler;
        this.gameObjectManager = gameObjectManager;
    }
    
    public System.Numerics.Vector2[] getGlobalCorrectCoordinate(int stageNumber, bool isUpSideImage)
    {
        return jsonFileManager.getAnswers(stageNumber).Select(answerType => 
        {
            return exchangeToGlobalCoordinate(answerType, isUpSideImage);
        }
        ).ToArray();
    }

    public System.Numerics.Vector2 exchangeToGlobalCoordinate(AnswerType coordinateInImage, bool isUpSideImage)
    {
        System.Numerics.Vector2 imagePosition = gameObjectManager.getMainImagePosition(isUpSideImage);
        return new System.Numerics.Vector2(imagePosition.X + coordinateInImage.x, imagePosition.Y + coordinateInImage.y);
    }
}