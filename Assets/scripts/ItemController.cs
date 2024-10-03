using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private float Maxspeed = 5f;
    private Rigidbody myrigid;
    // Start is called before the first frame update
    void Start()
    {
        this.myrigid=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void FixedUpdate()
    {
        speedControl();
    }
    //速度上限
    void speedControl()
    {
        /*
        //x方向の処置
        if (this.myrigid.velocity.x > this.Maxspeed)
        {
            this.myrigid.velocity = new Vector3(this.Maxspeed, this.myrigid.velocity.y, this.myrigid.velocity.z);
        }
        if (this.myrigid.velocity.x < -this.Maxspeed)
        {
            this.myrigid.velocity = new Vector3(-this.Maxspeed, this.myrigid.velocity.y, this.myrigid.velocity.z);
        }
        //y方向の処理
        if (this.myrigid.velocity.y > 0)
        {
            this.myrigid.velocity= new Vector3(this.myrigid.velocity.x, 0, this.myrigid.velocity.z);
        }
        
        if (this.myrigid.velocity.y > this.Maxspeed)
        {
            this.myrigid.velocity = new Vector3(this.myrigid.velocity.x, this.Maxspeed, this.myrigid.velocity.z);
        }
        if (this.myrigid.velocity.y < -this.Maxspeed)
        {
            this.myrigid.velocity = new Vector3(this.myrigid.velocity.x, -this.Maxspeed, this.myrigid.velocity.z);
        }
        */
        

    }


}
