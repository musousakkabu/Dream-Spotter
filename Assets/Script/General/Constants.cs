public class Constants
{
    // 制限時間
    public static int baseTimerLimitSec = 300;
    // お手付き制限回数
    public static int baseLifeCount = 3;   
    
    // 正解判定タッチ誤差
    public static float correctTouchRange = 0.1f;

　　// 間違い探し画面の上の画像オブジェクト名
    public static string upSideImageObjName = "upSideImage";
    // 間違い探し画面の下の画像オブジェクト名
    public static string downSideImageObjName = "downSideImage";

    // 正解を記入したJSONのファイルパス
    public static string answerJsonFilePath = "Assets/Json/Answer.json";
}