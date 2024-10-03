using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameClearManager : MonoBehaviour
{
    //ゲームマネージャーを取得
    [SerializeField] private GameObject gamemanager;

    //gameClearのconfetti
    [SerializeField] private GameObject ConfettiObj;
    //confettiのbool
    private bool confettibool = false;

    //gameClearのbanner
    [SerializeField] private GameObject bannaerObj;
    //bannaerのbool
    private bool bannaerbool = false;
    //bannerのrecttransform取得
    [SerializeField] RectTransform b;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gamemanager.GetComponent<GameManager>().GameSceneNumber == 2 && this.confettibool == false)
        {
            b.DOScale(new Vector3(5f,1.5f,2f), 1f).SetEase(Ease.InOutQuart);
            //confettiを生成。場所指定やサイズ指定はここやprefabから
            Instantiate(this.ConfettiObj);
            this.confettibool = true;
            StartCoroutine("nextSceneTime");

            
            
        }
    }

    //シーン待機時間
    IEnumerator nextSceneTime()
    {
        yield return new WaitForSeconds(2.0f);
        //ステージ番号を増やす
        GameManager.stageNumber++;
        //次のシーンを読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
