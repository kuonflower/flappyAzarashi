using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時にGameControllerをFindしておく
        gameController = GameObject.FindWithTag("GameController");
    }


    //トリガーからExitしたらクリアとみなす
    private void OnTriggerExit2D(Collider2D collision)
    {
        //gameControllerにアタッチされているコンポーネント全てで
        //IncreaseScoreというメソッドを実行せよ
        //メソッドが見つからなければエラーを返せというメッセージ
        gameController.SendMessage("IncreaseScore");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
