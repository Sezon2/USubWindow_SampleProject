using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// SubWindow-Example of main toolbar extension and custom message popup
/// </summary>
public class TestWinD : MDIEditorWindow {

    private enum TestMsg
    {
        Msg1,
        Msg2,
    }

    [MenuItem("SubWindow example/4.Examples of main toolbar extensions and custom message popups")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinD>();
    }

    [EWSubWindow("SunWinA", EWSubWindowIcon.None)]
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "SubWinA");
        if (GUI.Button(new Rect(main.x, main.y + 20, main.width, 20), "Btn1"))
        {
            Debug.Log("Btn1 was pressed");
        }
    }

    [EWSubWindow("SunWinB", EWSubWindowIcon.None)]
    private void SubWinB(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "SubWinB");
        if (GUI.Button(new Rect(main.x, main.y + 20, main.width, 20), "Btn2"))
        {
            Debug.Log("Btn2 was pressed");
        }
    }

    [EWToolBar("tools/Test1")]
    private void Test1()
    {
        Debug.Log("Pressed test 1");
    }

    [EWToolBar("tools/Test2")]
    private void Test2()
    {
        Debug.Log("Pressed test 2");
    }

    [EWToolBar("tools/Test3")]
    private void Test3()
    {
        ShowMsgBox((int) TestMsg.Msg1, null);
    }


    [EWToolBar("tools/Test4")]
    private void Test4()
    {
        ShowMsgBox((int)TestMsg.Msg2, "Parameters xxxx");
    }

    [EWMsgBox((int) TestMsg.Msg1, 0.2f, 0.2f, 0.6f, 0.6f)]
    private void Msg1(Rect rect, System.Object obj)
    {
        if (GUI.Button(new Rect(rect.x, rect.y, rect.width, 20),"shut down"))
        {
            HideMsgBox();
        }
    }

    [EWMsgBox((int)TestMsg.Msg2, 100, 100, 200, 200, true, true, true, true)]
    private void Msg2(Rect rect, System.Object obj)
    {
        if (obj != null)
        {
            string arg = (string) obj;
            GUI.Label(new Rect(rect.x, rect.y, rect.width, 20), "Parameters：" + arg);
        }
        if (GUI.Button(new Rect(rect.x, rect.y + rect.height - 20, rect.width, 20), "shut down"))
        {
            HideMsgBox();
        }
    }
}
