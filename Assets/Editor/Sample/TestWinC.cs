using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// SubWindow-Toolbar and help bar example
/// </summary>
public class TestWinC : MDIEditorWindow {

    [MenuItem("SubWindow example/3.Toolbar and help bar example")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinC>();
    }

    [EWSubWindow("SunWinA", EWSubWindowIcon.None)]
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "It's a normal subwindow");
    }

    [EWSubWindow("SunWinB", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.Normal)]
    private void SubWinB(Rect main, Rect toolbar)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "This is a subwindow with a toolbar");

        if(GUIEx.ToolbarButton(new Rect(toolbar.x,toolbar.y, 100, toolbar.height), "btn")) { }
    }

    [EWSubWindow("SunWinC", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.None, SubWindowHelpBoxType.Locker)]
    private void SubWinC(Rect main, Rect helpBox)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "This is a subwindow with a HelpBox");
        GUI.Label(new Rect(helpBox.x, helpBox.y+10, helpBox.width, 20), "HelpBox");
    }

    [EWSubWindow("SunWinD", EWSubWindowIcon.None, true, SubWindowStyle.Default, EWSubWindowToolbarType.Normal, SubWindowHelpBoxType.Bottom)]
    private void SubWinD(Rect main, Rect toolbar, Rect helpBox)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "This is a subwindow with a toolbar and help box");
    }
}
