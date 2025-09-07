using UnityEngine;

class GameObjectManager: IGameObjectManager
{
    private IErrorHandler errorHandler;
    public GameObjectManager(IErrorHandler errorHandler)
    {
        this.errorHandler = errorHandler;
    }

    public GameObject getMainImageObj(bool isUpSideImage)
    {
        GameObject imageObj = GameObject.Find(isUpSideImage ? Constants.UP_SIDE_IMAGE_OBJECT_NAME : Constants.DOWN_SIDE_IMAGE_OBJECT_NAME);
        if (imageObj == null)
        {
            errorHandler.invalidObjectNameError(new InvalidObjectNameError(""));
        }
        return imageObj;
    }

    public System.Numerics.Vector2 getMainImagePosition(bool isUpSideImage)
    {
        GameObject imageObj = getMainImageObj(isUpSideImage);
        return new System.Numerics.Vector2(imageObj.transform.position.x, imageObj.transform.position.y);
    }

    public bool isImageObject(GameObject obj)
    {
        return obj.name == Constants.UP_SIDE_IMAGE_OBJECT_NAME || obj.name == Constants.DOWN_SIDE_IMAGE_OBJECT_NAME;
    }

    public System.Numerics.Vector2 getMainImageSize(bool isUpSideImage)
    {
        GameObject imageObj = getMainImageObj(isUpSideImage);
        BoxCollider2D collider = imageObj.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            errorHandler.colliderNotFoundError(new ColliderNotFoundError($"オブジェクト({imageObj.name})にコライダーが追加されていない。"));
        }
        return new System.Numerics.Vector2(collider.size.x, collider.size.y);
    }
}