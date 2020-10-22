using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //ゲームステート
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    //ゲームの得点
    int score;

    public AzarashiController azarashi;
    public GameObject blocks;
    public Text scoreLabel;
    public Text stateLabel;

    // Start is called before the first frame update
    void Start()
    {
        // 開始と同時にReadysステートに移行
        Ready();
    }

    private void LateUpdate()
    {
        //ゲームのステートごとにイベントを監視
        switch (state)
        {
            case State.Ready:
                //タッチしたらゲームスタート
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                    break;
            case State.Play:
                //キャラが死亡したらゲームオーバー
                if (azarashi.IsDead())
                {
                    GameOver();
                }
                break;
            case State.GameOver:
                //タッチしたらシーンをリロード
                if (Input.GetButtonDown("Fire1"))
                {
                    Reload();
                }
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        //各オブジェクトを無効状態にする
        azarashi.SetSteerActive(false);
        blocks.SetActive(false);

        //ラベルを更新
        scoreLabel.text = "Score :" + 0;

        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }

    void GameStart()
    {
        state = State.Play;

        //各オブジェクトを有効にする
        azarashi.SetSteerActive(true);
        blocks.SetActive(true);

        //最初の入力だけゲームコントローラーから渡す
        azarashi.Flap();

        // ラベルを更新
        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;

        //シーンの中のすべてのScrollObjectコンポーネントを探し出す
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        //全ScrollObjectのスクロール処理を無効にする
        foreach(ScrollObject so in scrollObjects)
        {
            so.enabled = false;
        }

        //ラベルを更新
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }
    void Reload()
    {
        //現在再生しているシーンの情報を取得
        Scene LoadScene = SceneManager.GetActiveScene();

        //現在のシーンから名前を取り出してLoadSceneメソッドに渡し、
        //同じシーンを再読み込み
        SceneManager.LoadScene(LoadScene.name);

    }


    // Update is called once per frame
    void Update()
    {
    }

    //得点加算用メソッド
    public void IncreaseScore()
    {
        score++;
        scoreLabel.text = "Score :" + score;
    }
}
