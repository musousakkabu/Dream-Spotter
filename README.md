# Dream-Spotter
# 間違い探しゲーム仕様書 (Unity版)
## 概要
Unityエンジンを使用し、スマートフォン向けのネイティブアプリとして「間違い探しゲーム」を開発します。プレーヤーは、左右に表示された2つの画像の中から間違いをタップして見つけます。

## ゲームのルール
ステージごとに2枚の画像が提示されます（正解画像と間違い箇所がある画像）。
プレーヤーは、間違いと思う箇所をタップします。
システムはタップした箇所が正解か不正解かを判定します。
正解: 間違い箇所をハイライトし、正解数をカウント。
不正解: 「お手付き」としてカウントされ、規定回数を超えるとゲームオーバー。
ステージクリアまたはゲームオーバーになるまで繰り返します。
ステージクリア条件: 全ての間違いを発見する。
ゲームオーバー条件: お手付き回数が上限を超える。
広告を視聴するとヒントが表示されます。

# 設計
## シーン構成
1. メインメニューシーン
    * スタートボタン
    * 設定ボタン
2. ゲームシーン
    * 左右の画像表示エリア
    * ヒントボタン
    * お手付きカウント表示
    * スコア表示
3. リザルトシーン
    * ステージクリア/ゲームオーバーの結果表示
    * 次のステージボタン
## スクリプト設計
1. ゲームマスター (GameMaster.cs)
    * 【役割】:ゲーム全体の進行管理を行います。
    * 【主要機能】:
         * ステージデータのロード
         * スコアとお手付きカウントの管理
         * ゲームの終了条件チェック
2. 画像管理 (ImageManager.cs)
    * 【役割】:左右の画像の表示とクリック判定を行います。
    * 【主要機能】:
        * 左右の画像を読み込み、表示
        * タップされた位置が間違い箇所かどうかを判定
        * 正解箇所のハイライト表示
3. ステージ管理 (StageManager.cs)
    * 【役割】:各ステージの進行管理と次ステージの準備を行います。
    * 【主要機能】:
        * ステージデータの初期化
        * 次のステージのロード
        * ステージごとの間違い箇所のデータ取得
4. ヒント管理 (HintManager.cs)
    * 【役割】:広告視聴後にヒントを表示します。
    * 【主要機能】:
        * ヒント用エフェクトの表示
        * 使用回数の制限
5. 広告管理 (AdManager.cs)
    * 【役割】:広告表示を管理し、ヒントの権限を付与します。
    * 【主要機能】:
        * 広告の表示
        * ヒント利用の許可
        * アセットの準備
## 画像データ
* ステージごとの正解画像と間違い画像のペア
* UIアセット
* ボタン、スコア表示、ヒントアイコン、リザルト画面
* エフェクトアセット
* タップしたときのエフェクト
* ヒント箇所を光らせるエフェクト
## 技術仕様
### 開発環境: Unity 2023 以降
* プログラミング言語: C#
* プラットフォーム: Android

### データ管理
* 間違い箇所の座標情報
* ステージ進捗データ
