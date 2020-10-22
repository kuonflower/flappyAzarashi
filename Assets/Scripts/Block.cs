using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;
    public GameObject pivot;

    // Start is called before the first frame update
    void Start()
    {
        //開始時の隙間の高さを変更
        ChangeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeHeight()
    {
        //ランダムな高さを生成して設定
        float height = Random.Range(minHeight, maxHeight);
        pivot.transform.localPosition = new Vector3(0, height, 0);

    }

    //ScrollObjectScriptからのメッセージを受け取って高さを変更
    void OnScrollEnd()
    {
        ChangeHeight();
    }
}
