# USubWindow

シンプルなUnityエディターウィンドウレイアウト拡張ツールで、主にツリー構造に基づいたサブフォームシステムを実装し、リフレクションにより各ウィンドウの描画方法を取得します。属性を追加するだけでサブウィンドウを描画できるので便利です。

![例1](doc/doc1.gif)

例：

```
[EWSubWindow("SunWinA", EWSubWindowIcon.Game)]
private void SubWinA(Rect main)
{
	GUI.Label(new Rect(main.x, main.y, main.width, 20), "SubWinA");

}

[EWSubWindow("Grid", EWSubWindowIcon.Game, true, SubWindowStyle.Grid)]
private void SubWinA(Rect main)
{
	if (GUI.Button(new Rect(main.x, main.y, 100, 20), "Btn"))
	{

	}
}
```

更新：

1.サブフォームアイコンをカスタマイズする

2.プレビュースタイルとグリッドスタイルを追加する

![](doc/doc2.gif)

3.ヘルプボックスとツールバー

![](doc/doc3.gif)

4.カスタムツールバーとMsgBox

5.レイアウトの保存

![](doc/doc4.jpg)

5.カスタムサブフォームDrawer

6.サブフォームのDrawerライフサイクル

7.サブフォームのロックをサポートし、右上隅のドロップダウンボックスインターフェイスをカスタマイズします

![](doc/doc5.png)

![](doc/doc6.jpg)

6.サブフォームのシリアル化のサポート

7.カスタムMsgBox Drawer

8.ウィンドウを動的に追加する
