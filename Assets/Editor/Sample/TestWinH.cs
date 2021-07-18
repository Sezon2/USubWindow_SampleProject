using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

/// <summary>
/// SubWindow-動的ウィンドウの例
/// </summary>
public class TestWinH : MDIEditorWindow
{
    private DynamicWin m_DynamicWin1;
    private DynamicWin m_DynamicWin2;


    [MenuItem("SubWindowの例/8.動的ウィンドウの例")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinH>();
    }
    
    private void SubWinA(Rect main)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "これは動的ウィンドウAです");
    }
    
    private void SubWinB(Rect main, Rect toolbar)
    {
        GUI.Label(new Rect(main.x, main.y, main.width, 20), "これは動的ウィンドウBです");
    }

    [EWToolBar("ツール/動的ウィンドウAを作成する")]
    private void Test1()
    {
        AddDynamicSubWindow("動的ウィンドウA", EWSubWindowIcon.Navigation, SubWinA);
    }

    [EWToolBar("ツール/動的ウィンドウAを削除します")]
    private void Test2()
    {
        RemoveDynamicSubWindow(SubWinA);
    }

    [EWToolBar("ツール/動的ウィンドウBを作成する")]
    private void Test3()
    {
        AddDynamicSubWindowWithToolBar("動的ウィンドウB", EWSubWindowIcon.Movie, EWSubWindowToolbarType.Mini, SubWinB);
    }


    [EWToolBar("ツール/動的ウィンドウBを削除します")]
    private void Test4()
    {
        RemoveDynamicSubWindow(SubWinB);
    }

    [EWToolBar("ツール/動的ウィンドウCを作成する")]
    private void Test5()
    {
        if (m_DynamicWin1 == null)
            m_DynamicWin1 = new DynamicWin("動的ウィンドウC", "XXXXXXX");
        AddDynamicSubWindow(m_DynamicWin1);
    }


    [EWToolBar("ツール/動的ウィンドウCを削除します")]
    private void Test6()
    {
        if (m_DynamicWin1 != null)
            RemoveDynamicSubWindow<DynamicWin>(m_DynamicWin1);
    }

    [EWToolBar("ツール/動的ウィンドウDを作成する")]
    private void Test7()
    {
        if (m_DynamicWin2 == null)
            m_DynamicWin2 = new DynamicWin("動的ウィンドウD", "YYYYYYY");
        AddDynamicSubWindow(m_DynamicWin2);
    }


    [EWToolBar("ツール/動的ウィンドウDを削除します")]
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
