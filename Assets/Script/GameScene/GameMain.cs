using UnityEngine;
using System.Numerics;

class GameMain: MonoBehaviour
{
    private ITouchImageEventManager touchEventManager;
    private IUserDataManager userDataManager;
    private ICustomTimer customTimer;
    private IGameEventsManager gameEventsManager;

    void Start()
    {
        initializeMembers();
        customTimer.StartTimer();
    }

    void Update()
    {
        // Androidの画面タッチは左クリックとして認識される
        if (Input.GetMouseButtonDown(0))
        {
            touchEventManager.touchEvent();
        }

        if (customTimer.getIsTimerActive())
        {
            customTimer.DecreaseFrame();
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
        this.gameEventsManager = gameEventsManager;
        this.customTimer = new CustomTimer(Constants.Numbers.BASE_TIMER_LIMIT_SEC, () => { gameEventsManager.gameOverEvent(); });
    }
}