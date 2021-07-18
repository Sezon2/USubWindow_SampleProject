using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

/// <summary>
/// SubWindow-Example of a custom subwindow object
/// </summary>
public class TestWinE : MDIEditorWindow {

    [MenuItem("SubWindow example/5.Example of a custom subwindow object")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinE>();
    }

    [EWSubWindow("SunWinA", EWSubWindowIcon.Game)]
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "SubWinA");
    }

    [EWSubWindow("SunWinB", EWSubWindowIcon.Project)]
    private void SubWinB(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "SubWinB");
    }

    public void TestFunc()
    {
        Debug.Log("Access from subwindow");
    }
}

[EWSubWindowHandle(typeof(TestWinE))]
[System.Serializable]
class TestDrawerForTestWinE : SubWindowCustomDrawer
{

    public override GUIContent Title
    {
        get
        {
            if (m_Title == null)
                m_Title = new GUIContent("DefaultTitle");
            return m_Title;
        }
    }

    public override EWSubWindowToolbarType toolBar
    {
        get { return m_ToolBar; }
    }

    private EWSubWindowToolbarType m_ToolBar = EWSubWindowToolbarType.None;

    [NonSerialized]
    private GUIContent m_Title;

    public string valueA = "xxx";

    public Vector3 valueB = Vector3.zero;

    public TestDrawerForTestWinE()
    {
    }

    public override void DrawMainWindow(Rect mainRect)
    {
        base.DrawMainWindow(mainRect);
        if (GUI.Button(new Rect(mainRect.x, mainRect.y, mainRect.width, 20), "Change the title"))
        {
            m_Title = new GUIContent("New title");
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 20, mainRect.width, 20), "Show toolbar"))
        {
            m_ToolBar = EWSubWindowToolbarType.Normal;
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 40, mainRect.width, 20), "Close toolbar"))
        {
            m_ToolBar = EWSubWindowToolbarType.None;
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 60, mainRect.width, 20), "Show help box"))
        {
            SetSubWindowHelpBoxType(SubWindowHelpBoxType.Locker);
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 80, mainRect.width, 20), "Close help box"))
        {
            SetSubWindowHelpBoxType(SubWindowHelpBoxType.None);
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 100, mainRect.width, 20), "Access the container form"))
        {
            ((TestWinE) container).TestFunc();
        }
        valueA = EditorGUI.TextField(new Rect(mainRect.x, mainRect.y + 120, mainRect.width, 20), "Value:", valueA);
        valueB = EditorGUI.Vector3Field(new Rect(mainRect.x, mainRect.y + 140, mainRect.width, 20), "ValueB:", valueB);
    }

    public override void Init()
    {
        base.Init();
        Debug.Log("Init");
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Debug.Log("Destroy");
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Debug.Log("Disbale");
    }

    public override void OnEnable()
    {
        base.OnEnable();
        Debug.Log("Enalbe");
    }
   
}

[EWSubWindowHandle(typeof(TestWinE))]
[System.Serializable]
class TestDrawerForTestWinE2 : SubWindowCustomDrawer, ISubWinCustomMenu, ISubWinLock
{
    public override GUIContent Title
    {
        get
        {
            if (m_Title == null)
                m_Title = new GUIContent("DefaultTitle2");
            return m_Title;
        }
    }

    public override EWSubWindowToolbarType toolBar
    {
        get { return EWSubWindowToolbarType.None; }
    }

    [NonSerialized]
    private GUIContent m_Title;

    public TestDrawerForTestWinE2()
    {
    }

    public void SetLockActive(bool isLockActive)
    {
        if (isLockActive)
            Debug.Log("Window lock");
        else
            Debug.Log("Unlock window");
    }

    public void AddCustomMenu(GenericMenu menu)
    {
        menu.AddItem(new GUIContent("Test1"), false, ClickMenu);
        menu.AddItem(new GUIContent("Test2"), false, ClickMenu);
        menu.AddItem(new GUIContent("Test3"), false, ClickMenu);
    }

    private void ClickMenu()
    {
        Debug.Log("Menu was pressed");
    }
}