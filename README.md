# USubWindow
## はじめに
このサンプルプロジェクト及び、USubWindowのスクリプトは[AsehesL氏](https://github.com/AsehesL)が作成されたものです。  
当方はこのサンプルプロジェクト及び、USubWindowのスクリプトを使いやすいように整理し、翻訳を行なっています。  
ただし、日本語以外の翻訳に関しては、機械翻訳の為、読みづらい文章になってしまっている可能性がある事を予め、ご了承ください。

## 概要
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

## 更新概要  
1.サブフォームのアイコンをカスタマイズする機能を追加。  
2.プレビュースタイルとグリッドスタイルを追加。

![](doc/doc2.gif)

3.ヘルプボックスとツールバーを追加。

![](doc/doc3.gif)

4.カスタムツールバーとMsgBoxを追加。  
5.レイアウトの保存機能を追加。

![](doc/doc4.jpg)

5.カスタムサブフォームDrawerを追加。  
6.サブフォームのDrawerライフサイクル。  
7.サブフォームのロックをサポートし、右上隅のドロップダウンボックスインターフェイスをカスタマイズします。

![](doc/doc5.png)

![](doc/doc6.jpg)

6.サブフォームのシリアル化のサポート。  
7.カスタムMsgBox Drawerを追加。  
8.ウィンドウを動的に追加及び、削除する機能。
