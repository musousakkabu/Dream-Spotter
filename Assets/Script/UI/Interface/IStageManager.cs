public interface IStageSelectManager
{
    // ステージが選択されたときの処理
    void OnStageSelected(int index);

    // ステージのリストを取得する
    Stage[] GetStages();
}

