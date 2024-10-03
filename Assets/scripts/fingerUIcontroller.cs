using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fingerUIcontroller : MonoBehaviour
{
    //Recttransform型を取得
    [SerializeField] RectTransform a;

    //ゲームマネージャーを取得
    [SerializeField] private GameObject gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gamemanager.GetComponent<GameManager>().GameSceneNumber == 0)
        {
            StartCoroutine("fingerAnimation");
        }   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&
            this.gamemanager.GetComponent<GameManager>().GameSceneNumber==0)
        {
            
            this.gamemanager.GetComponent<GameManager>().GameSceneCount();
            Destroy(this.gameObject);
        }
    }
    IEnumerator fingerAnimation()
    {
        while (this.gamemanager.GetComponent<GameManager>().GameSceneNumber == 0)
        {
            a.DOAnchorPos(new Vector3(-200, 100, 0), 1f).SetEase(Ease.InOutQuart);
            yield return new WaitForSeconds(1f);
            a.DOAnchorPos(new Vector3(200, 100, 0), 1f).SetEase(Ease.InOutQuart);
            yield return new WaitForSeconds(1f);

        }
        
    }
}
