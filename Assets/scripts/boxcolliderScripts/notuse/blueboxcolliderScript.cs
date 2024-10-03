using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blueboxcolliderScript : MonoBehaviour
{
    //テキストオブジェクト取得
    [SerializeField] private GameObject bluetext;
    //ぶつかったオブジェクト数記録
    private int itemcount = 0;
    //クリアに必要なオブジェクト数
    [SerializeField] private int clearItemcount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.bluetext.GetComponent<Text>().text = this.itemcount + "/"+clearItemcount;
    }

    //オブジェクトぶつかった際にテキスト変更
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            this.itemcount += 1;

        }
        else
        {
            this.clearItemcount += 1;
        }
    }
}

