DaTable
@ 2019 Niwashi Games
Version 1.0.1

DaTableはアイテムやモンスターなどのデータをリストにしてくれます。
データのパラメーターはスクリプトで自作できます。



[DaTable]
データをリスト化しているアセット。
DaTable Creator Window で作成し、
DaTable Window でリストを管理します。

- GetElement<T>(int number)
- GetElement<T>(string name)
- GetElementWithID<T>(string id)
リストの要素を取得します。

- int elementCount
リストの要素数のプロパティです。



[DaTable Element]
DaTable Elementを継承することでデータクラスとして使います。

- int number
リストの番号です。

- strint id
32桁の英数字です。



■使い方
[DaTable アセット]
1. Assets -> Create -> C# -> DaTable Element から スクリプトを作成。
2. Tools -> DaTable -> Window -> DaTable Creator から DaTable Creator Window を起動。
3. DaTable Element Script に '2.'で作ったスクリプトをセット。
4. アセット名を入れ、Create で生成。

[DaTable Window]
1. Tools -> DaTable -> Window -> DaTable から DaTable Window を起動。
2. Project Window から DaTableアセットを選択。
3. Addボタンで要素を追加。
4. 要素を選択して、Inspectorウィンドウでデータを設定。

■バージョン履歴
1.0.1
- DaTableウィンドウのアセットパスのテキストを修正
1.0.0
- 初期バージョン
