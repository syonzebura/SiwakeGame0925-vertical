using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class redboxcolliderscript : MonoBehaviour
{

    //テキストオブジェクト（分子）取得
    [SerializeField] private GameObject nowredtext;
    //テキストオブジェクト（分母）取得
    [SerializeField] private GameObject clearredtext;

    //得点カウントするオブジェクトのタグ設定
    [SerializeField] string colorTagName;

    //クリアするために必要なアイテム数
    [SerializeField] private int clearItemCount;
    //現在のアイテム数
    private int nowItemCount = 0;
    //上限アイテム数
    [SerializeField] private int Maxitem;
    //総アイテム数
    private int allItems = 0;

    //親である箱のオブジェクト
    [SerializeField] private GameObject boxgameobject;
    //爆発エフェクトのオブジェクト
    [SerializeField] private GameObject breakeffectobj;

    //分子増えた時のアニメーションの拡大率
    [SerializeField]float scaleMag=3f;

    //箱が壊れるかどうか（破壊確定後に点数が増えないようにする）
    private bool boxBreakbool = false;

    //ゲームマネージャーを取得
    [SerializeField] private GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boxBreakbool == false)
        {
            this.nowredtext.GetComponent<TextMeshProUGUI>().text
            = $"{ this.nowItemCount.ToString("F0")}";
            this.clearredtext.GetComponent<TextMeshProUGUI>().text
                = $"{ this.clearItemCount.ToString("F0")}";
        }
        
    }

    //オブジェクトぶつかった際にテキスト変更
    private void OnTriggerEnter(Collider other)
    {
        if(this.gamemanager.GetComponent<GameManager>().GameSceneNumber == 1)
        {
            if (boxBreakbool == false && this.Maxitem >= this.allItems)
            {
                if (other.gameObject.tag == $"{colorTagName}")
                {
                    this.allItems += 1;
                    StartCoroutine("nowItemCountAnimation");
                    this.nowItemCount += 1;


                }
                else if (other.gameObject.tag == "Untagged")
                {
                    //何も起こさない
                }
                else
                {
                    this.allItems += 1;

                    this.clearItemCount += 1;
                    this.clearredtext.transform.DOShakePosition(duration: 1f, strength: 10f);
                    //Destroy(other.gameObject);
                }
            }
            //限界までアイテム入った時の表示
            else if (this.Maxitem <= this.allItems)
            {
                this.nowItemCount = 0;
                this.clearItemCount = 99;
            }
        }
        
        
        

        
    }
    //分子増えた際のアニメーション
    IEnumerator nowItemCountAnimation()
    {
        
        this.nowredtext.transform.DOScale(new Vector3(0.95f, 0.71f, 0.95f)*scaleMag, 0.5f).SetEase(Ease.InOutQuart);
        yield return new WaitForSeconds(0.5f);
        this.nowredtext.transform.DOScale(new Vector3(0.95f, 0.71f, 0.95f), 0.5f).SetEase(Ease.InOutQuart);
        //必要アイテム数（得点）がゼロになったら箱を消す
        if (this.clearItemCount <= this.nowItemCount)
        {
            this.boxBreakbool = true;
            //以下拡大縮小演出しようとしたが原点の位置がずれていて失敗。
            //this.boxgameobject.transform.DOScale(new Vector3(this.boxgameobject.transform.localScale.x, this.boxgameobject.transform.localScale.y, this.boxgameobject.transform.localScale.z)*1.5f, 0.5f).SetEase(Ease.InOutQuart);
            //yield return new WaitForSeconds(0.5f);
            //this.boxgameobject.transform.DOScale(new Vector3(0, 0, 0), 0.1f).SetEase(Ease.InOutQuart);
            //yield return new WaitForSeconds(0.1f);

            //破壊時エフェクト。Instantiateの参照位置は親boxの原点がズレているため分子テキストの位置を代わりに参照
            Instantiate(this.breakeffectobj, this.nowredtext.transform.position, Quaternion.identity);
            this.gamemanager.GetComponent<GameManager>().BoxBreak();
            Destroy(this.boxgameobject);
        }
    }
}
