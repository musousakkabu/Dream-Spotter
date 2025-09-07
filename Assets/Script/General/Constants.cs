public class Constants
{
    // 制限時間
    public static int BASE_TIMER_LIMIT_SEC = 300;
    // お手付き制限回数
    public static int BASE_LIFE_COUNT = 3;   
    
    // 正解判定タッチ誤差
    public static float CORRECT_TOUCH_RANGE = 0.1f;

　　// 間違い探し画面の上の画像オブジェクト名
    public static string UP_SIDE_IMAGE_OBJECT_NAME = "upSideImage";
    // 間違い探し画面の下の画像オブジェクト名
    public static string DOWN_SIDE_IMAGE_OBJECT_NAME = "downSideImage";

    // 正解を記入したJSONのファイルパス
    public static string ANSWER_JSON_FILE_PATH = "Assets/Json/Answer.json";
}