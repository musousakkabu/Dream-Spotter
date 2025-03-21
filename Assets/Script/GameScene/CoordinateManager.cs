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
        // TODO: 実装
        return new System.Numerics.Vector2[0];
        // return jsonFileManager.getAnswers(stageNumber).Select(answerType => 
        // {
        //     return exchangeToGlobalCoordinate(answerType, isUpSideImage);
        // }
        // ).ToArray();
    }

    public System.Numerics.Vector2 exchangeToGlobalCoordinate(AnswerType coordinateInImage, bool isUpSideImage)
    {
        System.Numerics.Vector2 imagePosition = gameObjectManager.getMainImagePosition(isUpSideImage);
        System.Numerics.Vector2 imageSize = gameObjectManager.getMainImageSize(isUpSideImage);

        // AnswerTypeは画像を100等分したときの座標系なので、画像の大きさを用いて変換する
        float coordinateRatioX = coordinateInImage.x / 100;
        float coordinateRatioY = coordinateInImage.y / 100;
        return new System.Numerics.Vector2(imagePosition.X + coordinateRatioX * imageSize.X, imagePosition.Y + coordinateRatioY * imageSize.Y);
    }
}