using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickretryButton()
    {
        //ボタンが押されたら現在のシーンを再度読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
