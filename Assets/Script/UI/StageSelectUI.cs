using UnityEngine;
using UnityEngine.UI;

public class StageSelectUI : MonoBehaviour
{
    public Button[] stageButtons;  // ステージ選択ボタン
    public GameStateManager gameStateManager;  // GameStateManagerへの参照

    // ステージのデータ（例: ステージ名と背景画像など）
    public Stage[] stages;

    private void Start()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i;  // 変数のキャプチャに注意
            stageButtons[i].onClick.AddListener(() => OnStageSelected(index));
        }
    }

    // ステージ選択ボタンがクリックされたときに呼ばれる
    private void OnStageSelected(int index)
    {
        // 選ばれたステージ情報をGameStateManagerに渡す
        gameStateManager.SetSelectedStage(stages[index]);
        gameStateManager.ChangeState(GameStateManager.GameState.Playing);
    }
}
