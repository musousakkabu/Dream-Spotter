using UnityEngine;
using System.Numerics;

class GameMain: MonoBehaviour
{
    private ITouchImageEventManager touchEventManager;
    private IUserDataManager userDataManager;

    void Start()
    {
        initializeMembers();
    }

    void Update()
    {
        // Androidの画面タッチは左クリックとして認識される
        if (Input.GetMouseButtonDown(0))
        {
            touchEventManager.touchEvent();
        }
    }

    private void initializeMembers()
    {
        IErrorHandler errorHandler = new ErrorHandler();
        ICoordinateManager coordinateManager = new CoordinateManager(
            new JsonFileManager(errorHandler), 
            new ErrorHandler(),
            new GameObjectManager(errorHandler)
        );
        IGameObjectManager gameObjectManager = new GameObjectManager(errorHandler);
        IUserDataManager userDataManager = new UserDataManager();
        IGameEventsManager gameEventsManager = new GameEventsManager(userDataManager, coordinateManager);

        this.userDataManager = userDataManager;
        this.touchEventManager = new TouchImageEventManager(
            gameEventsManager, 
            userDataManager,
            coordinateManager,
            gameObjectManager,
            userDataManager.getLastSelectedStageNumber()
        );
    }
}