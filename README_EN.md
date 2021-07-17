# USubWindow
## Introduction
This sample project and USubWindow script were created by [Mr. AshesesL](https://github.com/AsehesL).
We have organized and translated this sample project and USubWindow script for ease of use.
However, please note that translations other than Japanese may be difficult to read due to machine translation.

## Overview
A simple Unity Editor window layout extension tool that implements a subform system primarily based on a tree structure and uses reflection to get how each window is drawn. It is convenient because you can draw a subwindow just by adding an attribute.

![Example 1](doc/doc1.gif)

Example：
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

## Update summary  
1.Added the ability to customize subform icons.  
2.Added preview style and grid style.

![](doc/doc2.gif)

3.Added help box and toolbar.

![](doc/doc3.gif)

4.Added custom toolbar and MsgBox.  
5.Added the function to save the layout.

![](doc/doc4.jpg)

5.Added custom subform Drawer.  
6.Subform Drawer life cycle.  
7.Supports subform locking and customizes the dropdown box interface in the upper right corner.

![](doc/doc5.png)

![](doc/doc6.jpg)

6.Support for subform serialization.  
7.Added custom MsgBox Drawer.  
8.Ability to dynamically add and remove windows.
