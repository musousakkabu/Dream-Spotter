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
        this.userDataManager = new UserDataManager();
        touchEventManager = new TouchImageEventManager(
            new GameEventsManager(new UserDataManager()), 
            new UserDataManager(),
            new CoordinateManager(
                new JsonFileManager(new ErrorHandler()), 
                new ErrorHandler(),
                new GameObjectManager(new ErrorHandler())
            ),
            new GameObjectManager(new ErrorHandler()),
            userDataManager.getLastSelectedStageNumber()
        );
    }
}