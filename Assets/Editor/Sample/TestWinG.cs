using UnityEngine;
using UnityEditor;
using System.Collections;
using EditorWinEx.Internal;

/// <summary>
/// SubWindow-カスタムフォームとメインフォーム間のメッセージ通信例
/// </summary>
public class TestWinG : MDIEditorWindow {

    public enum TestWinGMessageID
    {
        FromWin1,
        FromWin2,
        NotifyMainWindow,
    }

    [MenuItem("SubWindowの例/7.カスタムフォームとメインフォーム間のメッセージ通信例")]
    static void InitWin()
    {
        TestWinA.CreateWindow<TestWinG>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.AddListener<string>((int) TestWinGMessageID.NotifyMainWindow, this.OnListenEvent);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        this.RemoveListener<string>((int)TestWinGMessageID.NotifyMainWindow, this.OnListenEvent);
    }

    private void OnListenEvent(string winName)
    {
        Debug.LogFormat("受信ウィンドウ：{0}のメッセージ", winName);
    }
}

[EWSubWindowHandle(typeof(TestWinG))]
class TestDrawerForTestWinG : SubWindowCustomDrawer
{

    public override GUIContent Title
    {
        get { return m_Title; }
    }

    public override EWSubWindowToolbarType toolBar
    {
        get { return m_ToolBar; }
    }

    private EWSubWindowToolbarType m_ToolBar = EWSubWindowToolbarType.None;

    private GUIContent m_Title;

    private float m_Number;

    public TestDrawerForTestWinG()
    {
        m_Title = new GUIContent("ウィンドウ1");
    }

    public override void OnEnable()
    {
        base.OnEnable();

        this.AddListener<float>((int)TestWinG.TestWinGMessageID.FromWin2, this.OnListenEvent);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        this.RemoveListener<float>((int)TestWinG.TestWinGMessageID.FromWin2, this.OnListenEvent);
    }

    public override void DrawMainWindow(Rect mainRect)
    {
        base.DrawMainWindow(mainRect);
        if (GUI.Button(new Rect(mainRect.x, mainRect.y, mainRect.width, 20), "ウィンドウ2にメッセージを送信します"))
        {
            this.Broadcast((int)TestWinG.TestWinGMessageID.FromWin1);
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 20, mainRect.width, 20), "メインコンテナフォームにメッセージを送信します"))
        {
            this.Broadcast<string>((int)TestWinG.TestWinGMessageID.NotifyMainWindow, m_Title.text);
        }
        GUI.Label(new Rect(mainRect.x, mainRect.y + 40, mainRect.width, 20), "ウィンドウ2のメッセージコンテンツを受信する：" + m_Number);
    }

    private void OnListenEvent(float number)
    {
        this.m_Number = number;
        Debug.Log("ウィンドウ2からメッセージを受信しました");
    }
   
}

[EWSubWindowHandle(typeof(TestWinG))]
class TestDrawerForTestWinG2 : SubWindowCustomDrawer
{

    public override GUIContent Title
    {
        get { return m_Title; }
    }

    public override EWSubWindowToolbarType toolBar
    {
        get { return m_ToolBar; }
    }

    private EWSubWindowToolbarType m_ToolBar = EWSubWindowToolbarType.None;

    private GUIContent m_Title;

    private int m_MessageCount;

    public TestDrawerForTestWinG2()
    {
        m_Title = new GUIContent("ウィンドウ2");
    }

    public override void OnEnable()
    {
        base.OnEnable();
        this.AddListener((int)TestWinG.TestWinGMessageID.FromWin1, this.OnListenEvent);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        this.RemoveListener((int)TestWinG.TestWinGMessageID.FromWin1, this.OnListenEvent);
    }

    public override void DrawMainWindow(Rect mainRect)
    {
        base.DrawMainWindow(mainRect);
        if (GUI.Button(new Rect(mainRect.x, mainRect.y, mainRect.width, 20), "ウィンドウ1にメッセージを送信する"))
        {
            this.Broadcast<float>((int) TestWinG.TestWinGMessageID.FromWin2, Random.Range(0f, 100f));
        }
        if (GUI.Button(new Rect(mainRect.x, mainRect.y + 20, mainRect.width, 20), "メインコンテナフォームにメッセージを送信します"))
        {
            this.Broadcast<string>((int)TestWinG.TestWinGMessageID.NotifyMainWindow, m_Title.text);
        }
        GUI.Label(new Rect(mainRect.x, mainRect.y + 40, mainRect.width, 20), "ウィンドウ1で受信したメッセージの数：" + m_MessageCount);
    }

    private void OnListenEvent()
    {
        this.m_MessageCount++;
        Debug.Log("ウィンドウ1からメッセージを受信しました");
    }
}