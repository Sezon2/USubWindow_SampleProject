using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

/// <summary>
/// SubWindow-Dynamic window example
/// </summary>
public class TestWinH : MDIEditorWindow
{
    private DynamicWin m_DynamicWin1;
    private DynamicWin m_DynamicWin2;


    [MenuItem("SubWindow example/8.Dynamic window example")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinH>();
    }
    
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "This is dynamic window A");
    }
    
    private void SubWinB(Rect main, Rect toolbar)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "This is dynamic window B");
    }

    [EWToolBar("tools/Create dynamic window A")]
    private void Test1()
    {
        AddDynamicSubWindow("Dynamic window A", EWSubWindowIcon.Navigation, SubWinA);
    }

    [EWToolBar("tools/Delete dynamic window A")]
    private void Test2()
    {
        RemoveDynamicSubWindow(SubWinA);
    }

    [EWToolBar("tools/Create dynamic window B")]
    private void Test3()
    {
        AddDynamicSubWindowWithToolBar("Dynamic window B", EWSubWindowIcon.Movie, EWSubWindowToolbarType.Mini, SubWinB);
    }


    [EWToolBar("tools/Delete dynamic window B")]
    private void Test4()
    {
        RemoveDynamicSubWindow(SubWinB);
    }

    [EWToolBar("tools/Create dynamic window C")]
    private void Test5()
    {
        if (m_DynamicWin1 == null)
            m_DynamicWin1 = new DynamicWin("Dynamic window C", "XXXXXXX");
        AddDynamicSubWindow(m_DynamicWin1);
    }


    [EWToolBar("tools/Delete dynamic window C")]
    private void Test6()
    {
        if (m_DynamicWin1 != null)
            RemoveDynamicSubWindow<DynamicWin>(m_DynamicWin1);
    }

    [EWToolBar("tools/Create dynamic window D")]
    private void Test7()
    {
        if (m_DynamicWin2 == null)
            m_DynamicWin2 = new DynamicWin("Dynamic window D", "YYYYYYY");
        AddDynamicSubWindow(m_DynamicWin2);
    }


    [EWToolBar("tools/Delete dynamic window D")]
    private void Test8()
    {
        if (m_DynamicWin2 != null)
            RemoveDynamicSubWindow<DynamicWin>(m_DynamicWin2);
    }

    private class DynamicWin : SubWindowCustomDrawer
    {
        public override GUIContent Title
        {
            get { return m_Title; }
        }

        public override EWSubWindowToolbarType toolBar
        {
            get { return EWSubWindowToolbarType.Normal; }
        }

        private GUIContent m_Title;

        private string m_Arg;

        public DynamicWin(string title, string arg)
        {
            m_Title = new GUIContent(title);
            if (arg == null)
                m_Arg = "Null";
            else
                m_Arg = arg;
        }

        public override void DrawMainWindow(Rect mainRect)
        {
            base.DrawMainWindow(mainRect);
            GUI.Label(mainRect, "Arg:" + m_Arg);
        }
    }
}
