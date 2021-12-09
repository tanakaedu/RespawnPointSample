using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("ゲーム開始時のライフ数"), SerializeField]
    int defaultLife = 5;

    /// <summary>
    /// シーンを切り替える理由
    /// </summary>
    public enum SceneChangeType
    {
        None = -1,
        Title,
        Start,
        Retry,
        Gameover,
        Clear
    }

    static SceneChangeType nextState = SceneChangeType.Title;
    public static SceneChangeType CurrentState { get; private set; } = SceneChangeType.None;

    /// <summary>
    /// 現在の残りライフ
    /// </summary>
    public static int CurrentLife { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        if (nextState == SceneChangeType.None)
        {
            return;
        }

        CurrentState = nextState;
        nextState = SceneChangeType.None;

        switch (CurrentState)
        {
            case SceneChangeType.Title:
            case SceneChangeType.Start:
            case SceneChangeType.Retry:
                // todo 本番ではタイトルシーンの読み込みに変更
                if (CurrentState == SceneChangeType.Title)
                {
                    CurrentState = SceneChangeType.Start;
                }
                // todo ここまで

                // ステージを再読み込み
                if (SceneManager.GetSceneByName("Stage").IsValid())
                {
                    SceneManager.UnloadScene("Stage");
                }
                SceneManager.LoadScene("Stage", LoadSceneMode.Additive);
                break;
        }
    }

    /// <summary>
    /// シーンの切り替え要求
    /// </summary>
    /// <param name="next">切り替えたいシーンを指定</param>
    public static void RequestChange(SceneChangeType next)
    {
        if (nextState == SceneChangeType.None)
        {
            nextState = next;
        }
    }
}
