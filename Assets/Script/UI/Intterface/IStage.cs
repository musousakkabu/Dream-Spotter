using UnityEngine;
public interface IStage
{
    // ステージ名
    string StageName { get; }

    // ステージの説明
    string Description { get; }

    // ステージの背景画像
    Sprite BackgroundImage { get; }

    // ステージ番号（必要な場合）
    int StageNumber { get; }
}
