using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// SubWindow-ツールバーとヘルプバーの例
/// </summary>
public class TestWinC : MDIEditorWindow {

    [MenuItem("SubWindowの例/3.ツールバーとヘルプバーの例")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinC>();
    }

    [EWSubWindow("SunWinA", EWSubWindowIcon.None)]
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "普通のサブウィンドウです");
    }

    [EWSubWindow("SunWinB", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.Normal)]
    private void SubWinB(Rect main, Rect toolbar)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "これはツールバー付きのサブウィンドウです");

        if(GUIEx.ToolbarButton(new Rect(toolbar.x,toolbar.y, 100, toolbar.height), "btn")) { }
    }

    [EWSubWindow("SunWinC", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.None, SubWindowHelpBoxType.Locker)]
    private void SubWinC(Rect main, Rect helpBox)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "これはHelpBoxを備えたサブウィンドウです");
        GUI.Label(new Rect(helpBox.x, helpBox.y+10, helpBox.width, 20), "HelpBox");
    }

    [EWSubWindow("SunWinD", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.Normal, SubWindowHelpBoxType.Bottom)]
    private void SubWinD(Rect main, Rect toolbar, Rect helpBox)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "これはツールバーとヘルプボックスを備えたサブウィンドウです");
    }
}
