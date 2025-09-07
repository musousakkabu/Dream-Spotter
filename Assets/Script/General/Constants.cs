public static class Constants
{
    public static class Numbers
    {
        // 制限時間
        public const int BASE_TIMER_LIMIT_SEC = 300;
        // お手付き制限回数
        public const int BASE_LIFE_COUNT = 3;   
        
        // 正解判定タッチ誤差
        public const float CORRECT_TOUCH_RANGE = 0.1f;
    }

    public static class GameObjectNames
    {
        // 間違い探し画面の上の画像オブジェクト名
        public const string UP_SIDE_IMAGE_OBJECT_NAME = "upSideImage";
        // 間違い探し画面の下の画像オブジェクト名
        public const string DOWN_SIDE_IMAGE_OBJECT_NAME = "downSideImage";
    }


    public static class Path
    {
        // JSONファイルがまとめられたディレクトリのパス
        public const string JSON_DIR_PATH = "Assets/Json/StageMasterData";
        // ステージマスターデータを保持するディレクトリパス
        public const string stageMasterDataDirPath = JSON_DIR_PATH + "/" + "StageMasterData";
    }
}