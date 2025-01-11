/// <summary>
/// ユーザーデータの保存、取り出しを担当する
/// </summary>
// TODO: 設定の保存とゲームデータの保存は分ける？
interface IUserDataManager
{
    /// <summary>
    /// クリアしたステージ番号を保存する
    /// </summary>
    void saveResolvedStageNumber(int stageNumber);

    /// <summary>
    /// チュートリアルを完了した事を保存する
    /// </summary>
    void saveIsDoneTutorial();

    /// <summary>
    /// 設定項目を保存する
    /// </summary>
    void saveSoundSetting(soundVolumeLevel: Int);
}