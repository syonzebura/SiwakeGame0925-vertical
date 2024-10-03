using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGanarater : MonoBehaviour
{
    
    //フラグ変数
    private bool ganarateflag = false;
    //降ってくるアイテムを格納、nextControllerと対応させたい
    public GameObject[] items;
    //ゲームマネージャーを取得
    [SerializeField] private GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.ganarateflag == false&&
            this.gamemanager.GetComponent<GameManager>().GameSceneNumber == 1)
        {
            StartCoroutine("waitGanaratetime");
        }

    }

    IEnumerator waitGanaratetime()
    {
        this.ganarateflag = true;
        yield return new WaitForSeconds(1.5f);
        GameObject @object = Instantiate(items[Random.Range(0,items.Length)]);
        @object.transform.position = new Vector3(0, 6.5f, 0);
        this.ganarateflag = false;
    }
}
