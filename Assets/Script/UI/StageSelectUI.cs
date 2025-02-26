using UnityEngine;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour, IStageSelectManager
{
    public Button[] stageButtons;
    public GameStateManager gameStateManager;
    public Stage[] stages;

    private void Start()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i;
            stageButtons[i].onClick.AddListener(() => OnStageSelected(index));
        }
    }

    public Stage[] GetStages()
    {
        return stages;  // ステージの配列を返す
    }


    public void OnStageSelected(int index)
    {
        // ステージ選択
        gameStateManager.SetSelectedStage(stages[index]);
        gameStateManager.ChangeState(GameStateManager.GameState.Playing);
    }
}

