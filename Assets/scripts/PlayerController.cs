using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //マウスとゲームオブジェクトの座標データを格納
    Vector3 mousePos, pos;
    //rigidbody取得
    private Rigidbody myrigid;
    [SerializeField] private float PlayerFollowSpeed;

    //bool
    private bool clickjuge = false;

    // Start is called before the first frame update
    void Start()
    {
        this.myrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && clickjuge == false)
        {
            Mouseclick();
        }
    }

    //マウスが押されている間の処理
    void Mouseclick()
    {
        this.clickjuge = true;
        this.mousePos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        var towardPos = Vector3.MoveTowards(this.transform.position,
            new Vector3(this.pos.x, this.transform.position.y, this.transform.position.z), this.PlayerFollowSpeed);
        this.myrigid.MovePosition(towardPos);
        
        this.clickjuge = false;
    }
}
