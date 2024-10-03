using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ゲームシーンの変数。0：スタート時　１：ゲーム中　２：ゲームクリア時
    public int GameSceneNumber = 0;
    //ゲームシーンのboxの数
    public int boxcount;

    //ゲームのステージ番号
    public static int stageNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.stageNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.boxcount == 0)
        {
            this.GameSceneNumber = 2;
        }
    }

    public void GameSceneCount()
    {
        this.GameSceneNumber++;
    }
    public void BoxBreak()
    {
        this.boxcount--;
    }
}
